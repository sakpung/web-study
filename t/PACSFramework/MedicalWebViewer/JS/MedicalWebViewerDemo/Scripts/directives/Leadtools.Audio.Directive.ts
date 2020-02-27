// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('leadAudio', ["eventService", "$timeout", function (eventService: EventService,$timeout): ng.IDirective {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            uiType: "=", // valid values are: playback, none, download, wait            
            audioSource: "=",
        },
        templateUrl: 'views/templates/AudioPlayer.html',
        link: function (scope : any, elem, attr: any) {                        
            scope.$watch('uiType', function (newValue: string, oldValue: string) {
                if (newValue) {
                    switch (newValue) {
                        case 'playback':
                            buildPlaybackUI(scope);
                            break;
                        case 'download':
                            buildDownloadUI();
                            break;
                        case 'none':
                            buildNoAudioUI();
                            break;
                        case 'wait':
                            buildWaitUI();
                            break;
                    }
                }
            });

            scope.$watch('audioSource', function (newValue: string, oldValue: string) {
                if (newValue) {
                    if (scope.uiType == 'playback') {
                        var player = document.getElementById("WaveformBasicAudioPlayer");
                        var source: HTMLSourceElement = <HTMLSourceElement>player.lastChild;

                        if (source) {
                            source.src = scope.audioSource;
                            if (source['controls'])
                                source['controls'] = true;
                        }
                    }
                    else if (scope.uiType == 'download') {
                        var WaveformBasicAudioPlayerDownloadLink:HTMLAnchorElement = <HTMLAnchorElement>document.getElementById("WaveformBasicAudioPlayerDownloadLink");

                        WaveformBasicAudioPlayerDownloadLink.href = scope.audioSource; //_objectRetrieveProxy.BuildAudioUrl(_frame.Instance.SOPInstanceUID, 0, 'audio/wav');
                    }
                }
            });
            
            function buildPlaybackUI(scope) {
                var waveformBasicAudioDlg = document.getElementById("WaveformBasicAudioDiv");
                var WaveformBasicAudioPlayerDownloadLinkTable = document.getElementById("WaveformBasicAudioPlayerDownloadLinkTable");
                var WaveformBasicAudioPlayerDownloadLink = document.getElementById("WaveformBasicAudioPlayerDownloadLink");
                var WaveformBasicAudioPlayerNoAudio = document.getElementById("WaveformBasicAudioPlayerNoAudio");   
                var WaveformBasicAudioPlayerWait = document.getElementById("WaveformBasicAudioPlayerWait");               
                var player: HTMLAudioElement = <HTMLAudioElement>document.getElementById("WaveformBasicAudioPlayer");
                var canPlayWAVE = !!player.canPlayType && player.canPlayType('audio/wav') != "";
                var canPlay = !!canPlayWAVE;                

                if (canPlay) {
                    waveformBasicAudioDlg.style.display = 'inherit';
                    player.style.display = 'inherit';
                    WaveformBasicAudioPlayerNoAudio.style.display = 'none';
                    WaveformBasicAudioPlayerDownloadLinkTable.style.display = 'none';
                    WaveformBasicAudioPlayerWait.style.display = 'none';                    

                    removeAllChildren(player);
                    var audioSrc: HTMLSourceElement;

                    audioSrc = <HTMLSourceElement>document.createElement('source');
                    audioSrc.type = 'audio/wav';
                    player.appendChild(audioSrc);
                }
                else {
                    scope.uiType = 'download';
                    scope.$apply();                    
                }
            }
            
            function buildDownloadUI() {
                var waveformBasicAudioDlg = document.getElementById("WaveformBasicAudioDiv");
                var WaveformBasicAudioPlayerDownloadLinkTable = document.getElementById("WaveformBasicAudioPlayerDownloadLinkTable");
                var WaveformBasicAudioPlayerDownloadLink = document.getElementById("WaveformBasicAudioPlayerDownloadLink");
                var WaveformBasicAudioPlayerNoAudio = document.getElementById("WaveformBasicAudioPlayerNoAudio");        
                var WaveformBasicAudioPlayerWait = document.getElementById("WaveformBasicAudioPlayerWait");        
                var player = document.getElementById("WaveformBasicAudioPlayer");

                waveformBasicAudioDlg.style.backgroundColor = '#FFFFFF';
                player.style.display = 'none';
                WaveformBasicAudioPlayerNoAudio.style.display = 'none';
                waveformBasicAudioDlg.style.display = 'inherit';
                WaveformBasicAudioPlayerDownloadLinkTable.style.display = 'inherit';  
                WaveformBasicAudioPlayerWait.style.display = 'none';              
            }
            
            function buildNoAudioUI() {
                var waveformBasicAudioDlg = document.getElementById("WaveformBasicAudioDiv");
                var WaveformBasicAudioPlayerDownloadLinkTable = document.getElementById("WaveformBasicAudioPlayerDownloadLinkTable");
                var WaveformBasicAudioPlayerDownloadLink = document.getElementById("WaveformBasicAudioPlayerDownloadLink");
                var WaveformBasicAudioPlayerNoAudio = document.getElementById("WaveformBasicAudioPlayerNoAudio");
                var WaveformBasicAudioPlayerWait = document.getElementById("WaveformBasicAudioPlayerWait");
                var player = document.getElementById("WaveformBasicAudioPlayer");

                waveformBasicAudioDlg.style.display = 'inherit';
                waveformBasicAudioDlg.style.backgroundColor = '#FFFFFF';
                player.style.display = 'none';
                WaveformBasicAudioPlayerNoAudio.style.display = 'inherit';
                WaveformBasicAudioPlayerDownloadLinkTable.style.display = 'none';
                WaveformBasicAudioPlayerWait.style.display = 'none';
            } 

            function buildWaitUI() {

                var waveformBasicAudioDlg = document.getElementById("WaveformBasicAudioDiv");
                var WaveformBasicAudioPlayerDownloadLinkTable = document.getElementById("WaveformBasicAudioPlayerDownloadLinkTable");
                var WaveformBasicAudioPlayerDownloadLink = document.getElementById("WaveformBasicAudioPlayerDownloadLink");
                var WaveformBasicAudioPlayerNoAudio = document.getElementById("WaveformBasicAudioPlayerNoAudio");
                var WaveformBasicAudioPlayerWait = document.getElementById("WaveformBasicAudioPlayerWait");
                var player = document.getElementById("WaveformBasicAudioPlayer");

                waveformBasicAudioDlg.style.display = 'inherit';
                waveformBasicAudioDlg.style.backgroundColor = '#FFFFFF';
                player.style.display = 'none';
                WaveformBasicAudioPlayerNoAudio.style.display = 'none';
                WaveformBasicAudioPlayerDownloadLinkTable.style.display = 'none';
                WaveformBasicAudioPlayerWait.style.display = 'inherit';
            }
       
            
            function removeAllChildren(element:HTMLElement) {
                try {
                    while (element.hasChildNodes()) {
                        element.removeChild(element.lastChild);
                    }
                }
                catch (ex) {
                    //some browsers report error when item is not found, ignored here
                }
            }          
        }    
    };    
}]);