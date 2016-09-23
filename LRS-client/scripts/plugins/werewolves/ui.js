var FIVES = FIVES || {};
FIVES.Plugins = FIVES.Plugins || {};

(function () {

    "use strict";
    var _fivesCommunicator = FIVES.Communication.FivesCommunicator;

    var werewolves_UI = function() {
        FIVES.Events.AddConnectionEstablishedHandler(this._createFunctionWrappers.bind(this));
        $('.ui.dropdown').dropdown();
        $('.activating.element')
            .popup('hide')
        ;

        $('#select_num').dropdown({
                action: function(text, value) {
                    // nothing built in occurs
                    //console.log(text)
                    $('#select_num').dropdown('set selected', text)
                    //$('#select_num').dropdown('set value', text)
                    $('#select_num').dropdown('hide') //TODO: always trigger twice
                    $('#select_config').dropdown('set selected', value)

                    //$('#build_game').popup('remove popup');
                }
            }
        )

        $('#select_config').dropdown({
            action: function(text, value) {
                //console.log(text + value)

                $('#select_config').dropdown('set selected', text)
                $('#select_config').dropdown('hide')

                $('#select_num').dropdown('set text', value)

                //$('#build_game').popup('remove popup');
            }
        })

        $('#build_game').mousemove(function(){
            var num = $('#select_num').dropdown('get text')
            var config = $('#select_config').dropdown('get value')

            if (num == "" || config == "")
            {
                $('#build_game').popup('show');
            }
            else
            {
                $('#build_game').popup('remove popup');
            }
        })

        $('#build_game').click(function(){
            //console.log($('#select_num').dropdown('get text'))
            //console.log($('#select_config').dropdown('get value'))

            var num = $('#select_num').dropdown('get text')
            var config = $('#select_config').dropdown('get value')

            if (num == "" || config == "")
            {
                //$('#build_game').popup('show');
            }
            else
            {
                console.log("Start building a werewolves game...")
            }
        })
    };

    var w = werewolves_UI.prototype;

    w._createFunctionWrappers = function (){

    }



    FIVES.Plugins.werewolves_UI = new werewolves_UI();
}());
