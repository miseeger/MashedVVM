MashedVVM
==========

MashedVVM is a quite lightweight MVVM framework that brings an 'INotifyable' data class and 
abstract ViewModel base classes plus an also abstract View base class. There are also Interfaces 
provided which are implemented in those classes to have them ready-to-use in an IoC scenario 
(like PRISM using Unity). It is stricly limited to WPF and it supports the ViewModel-First paradigm.

The library combines ideas from other MVVM libraries with some ideas from lessons learned in a 
couple of video tutorial sessions and books. 

To have a closer look on how to use MashedVVM, please refer to the tests ;-)

The 'mashed' parts of the framework are as followes:
<ul>
<li>MessageBroker to send and receive Messages between ViewModels.</li>
<li>RelayCommand providing RaiseCanExecuteChanged.</li>
<li>Locator to register ViewModels or Services in order to have a simple IoC.</li>
<li>Attached Command Behavior to bind Commands to certain Events of WPF Controls.</li>
</ul>

!!! This project is currently a work-in-progress and some parts are not tested, yet. You use it at your own risk !!!


