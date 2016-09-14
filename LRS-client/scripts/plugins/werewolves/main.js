var FIVES = FIVES || {};
FIVES.Plugins = FIVES.Plugins || {};

(function () {

    "use strict";
    var _fivesCommunicator = FIVES.Communication.FivesCommunicator;

    var werewolves = function() {
        FIVES.Events.AddConnectionEstablishedHandler(this._createFunctionWrappers.bind(this));
    };

    var w = werewolves.prototype;

    w._createFunctionWrappers = function (){

    }

    FIVES.Plugins.werewolves = new werewolves();
}());
