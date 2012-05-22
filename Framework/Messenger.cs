/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is provided as is and should be used at your own risk. It comes *
 * without a warrenty of any kind.                                           *
 * ************************************************************************* */

using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Threading; 
 
namespace MashedVVM
{

	public class Messenger
	{

		private static Messenger _messengerInstance;
		private static readonly object SyncLock = new object();
		private readonly Dictionary<Type, List<ActionIdentifier>> _actionRefs = new Dictionary<Type, List<ActionIdentifier>>();
		private readonly List<ActionIdentifier> _untypedActionRefs = new List<ActionIdentifier>();


		private Messenger() { }


		public static Messenger Instance
		{
			get
			{
				lock (SyncLock)
				{
					return _messengerInstance ?? (_messengerInstance = new Messenger());
				}
			}
		}


		public void Register(object recipient, string identCode, Action action)
		{
			var actionIdent = new ActionIdentifier
			{Action = new WeakReferenceAction(recipient, action), IdentificationCode = identCode};
			_untypedActionRefs.Add(actionIdent);
		}


		public void Register<T>(object recipient, Action<T> action)
		{
			Register<T>(recipient, null, action);
		}


		public void Register<T>(object recipient, string messageId, Action<T> action)
		{
			var messageType = typeof(T);

			if (!_actionRefs.ContainsKey(messageType))
			{
				_actionRefs.Add(messageType, new List<ActionIdentifier>());
			}

			var actionIdent = new ActionIdentifier
									{
										Action = new WeakReferenceAction<T>(recipient, action),
										IdentificationCode = messageId
									};

			_actionRefs[messageType].Add(actionIdent);
		}


		public void Send(string identCode)
		{
			var identifiers = _untypedActionRefs
				.Where(item => item.IdentificationCode.Equals(identCode))
				.ToList();
			identifiers.ForEach(item => item.Action.Execute());
		}


		public void Send<TNotification>(TNotification notification)
		{
			var type = typeof(TNotification);
			var typeActionIdentifiers = _actionRefs[type];
			foreach (var actionIdentifier in typeActionIdentifiers)
			{
				var actionParameter = actionIdentifier.Action as IActionParameter;
				if (actionParameter != null)
				{
					actionParameter.ExecuteWithParameter(notification);
				}
				else
				{
					actionIdentifier.Action.Execute();
				}
			}
		}


		public void Send<T>(T notification, string messageId)
		{
			var type = typeof(T);
			var typeActionIdentifiers = _actionRefs[type];
			
			foreach (var ai in typeActionIdentifiers)
			{
				if (ai.IdentificationCode == messageId)
				{
					var actionParameter = ai.Action as IActionParameter;
					if (actionParameter != null)
					{
						actionParameter.ExecuteWithParameter(notification);
					}
					else
					{
						ai.Action.Execute();
					}
				}
			}
		}


		public void Unregister(string identCode)
		{
			var lockTaken = false;
			
			try
			{
				Monitor.Enter(_untypedActionRefs, ref lockTaken);
				foreach (var weakRefAction in _untypedActionRefs)
				{
					if (weakRefAction.Action != null && weakRefAction.Action.Target != null)
					{
						if (String.IsNullOrEmpty(identCode)
							|| (!String.IsNullOrEmpty(identCode)
								&& !String.IsNullOrEmpty(weakRefAction.IdentificationCode)
								&& weakRefAction.IdentificationCode.Equals(identCode)))
						{
							weakRefAction.Action.Unload();
						}
					}
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(_actionRefs);
				}
			}
		}


		public void Unregister<TNotification>(object recipient)
		{
			Unregister<TNotification>(recipient, null);
		}


		public void Unregister<T>(object recipient, string messageId)
		{
			var lockTaken = false;

			try
			{
				Monitor.Enter(_actionRefs, ref lockTaken);
				foreach (var targetType in _actionRefs.Keys)
				{
					foreach (var weakRefAction in _actionRefs[targetType])
					{
						if (weakRefAction.Action != null && weakRefAction.Action.Target != null && weakRefAction.Action.Target.Target == recipient)
						{
							if (String.IsNullOrEmpty(messageId)
								|| (!String.IsNullOrEmpty(messageId)
									&& !String.IsNullOrEmpty(weakRefAction.IdentificationCode)
									&& weakRefAction.IdentificationCode.Equals(messageId)))
							{
								weakRefAction.Action.Unload();
							}
						}
					}
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(_actionRefs);
				}
			}

		}

		

		public class WeakReferenceAction
		{

			private WeakReference _target;
			private Action _action;


			public WeakReferenceAction(object target, Action action)
			{
				_target = new WeakReference(target);
				_action = action;
			}


			public WeakReference Target
			{
				get
				{
					return _target;
				}
			}


			public void Execute()
			{
				if (_action != null && _target != null && _target.IsAlive)
				{
					_action.Invoke();
				}
			}


			public void Unload()
			{
				_target = null;
				_action = null;
			}

		}

		

		public class WeakReferenceAction<T> : WeakReferenceAction, IActionParameter
		{

			private readonly Action<T> _action;


			public WeakReferenceAction(object target, Action<T> action)
				: base(target, null)
			{
				_action = action;
			}


			public void Execute()
			{
				if (_action != null && Target != null && Target.IsAlive)
				{
					_action(default(T));
				}
			}


			public void Execute(T parameter)
			{
				if (_action != null && Target != null && Target.IsAlive)
				{
					_action(parameter);
				}
			}


			public Action<T> Action
			{
				get
				{
					return _action;
				}
			}


			public void ExecuteWithParameter(object parameter)
			{
				Execute((T)parameter);
			}

		}



		public class ActionIdentifier
		{

			public WeakReferenceAction Action { get; set; }
			public string IdentificationCode { get; set; }

		}


		interface IActionParameter
		{
			void ExecuteWithParameter(object parameter);
		}

	}

}
