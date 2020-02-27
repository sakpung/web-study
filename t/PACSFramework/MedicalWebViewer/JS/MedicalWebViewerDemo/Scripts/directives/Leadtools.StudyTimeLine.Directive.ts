// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

module TimeLineState {
    export var Start: string = "start";
    export var QueryTimeLine: string = "querytimeline";
    export var LoadThumbs: string = "loadthumbs";
    export var ErrorReport: string = "error";
    export var SuccessReport: string = "success";
    export var End: string = "end";
}

module TimeLineTransition {
    export var Success: string = "success";
    export var Failure: string = "failure";
    export var Aborted: string = "aborted";
}

directives.directive('studyTimeline', ["eventService", "$timeout", "queryArchiveService", "seriesManagerService", "authenticationService", "dataService", "optionsService", function (eventService: EventService, $timeout, queryArchiveService: QueryArchiveService, seriesManagerService: SeriesManagerService,
    authenticationService: AuthenticationService, dataService:DataService, optionsService: OptionsService): ng.IDirective {
    return {
        replace: true,
        template: '<div></div>',
        scope: {
            retrieveUrl: '=',
            api: '=',
            replaceCell: '&',
            appendCell: '&'
        },
        link: function (scope : any, elem:ng .IAugmentedJQuery, attr: any) {
            var timelineState = TimeLineState.Start;
            var thumbnailDiv: ng.IAugmentedJQuery = angular.element('<div/>');
            var scrollStartPosX: number;
            var scrollStartPosY: number;
            var currentStudyInstanceUID: string;
            var currentPatientID: string;
            var dateFormat = optionsService.get(OptionNames.DateFormat);

            elem.append(thumbnailDiv);
            sizeToParent($(elem), $(elem).parent());

            $(elem).parent().resize(function (e, data) {
                sizeToParent($(elem), $(elem).parent());
            });

            function sizeToParent($elem, $parent) {
                $elem.width($parent.width());
                $elem.height($parent.height());
            }

            scope.api = scope.api || {};

            scope.api.toggle = function (studyInstanceUID: string, patientID: string, hide: boolean) {
                var isVisible: boolean;

                currentPatientID = patientID;
                currentStudyInstanceUID = studyInstanceUID;
                isVisible = !hide;

                if (isVisible) {
                    sizeToParent($(elem), $(elem).parent());
                    transitionState(TimeLineTransition.Aborted, "");
                    restart();
                    transitionState(TimeLineTransition.Success, "");
                }
                else {
                    transitionState(TimeLineTransition.Aborted, "");
                }
            }

            scope.api.refresh = function (patientID: string, studyInstanceUID: string, seriesInstanceUID: string) {
                var isVisible: boolean = elem.is(':visible');

                if ((studyInstanceUID == currentStudyInstanceUID) || (patientID == currentPatientID))
                 {
                    if (isVisible)
                    {
                        hilightSeries(seriesInstanceUID);
                    }
                    return;
                }

                if (isVisible) {
                    currentStudyInstanceUID = studyInstanceUID;
                    currentPatientID = patientID;
                    transitionState(TimeLineTransition.Aborted, "");
                    restart();
                    transitionState(TimeLineTransition.Success, "");
                }
            }

            function restart() {
                timelineState = TimeLineState.Start;
            }

            function transitionState(transition, extraInfo) {
                if (transition == TimeLineTransition.Aborted) {
                    timelineState = TimeLineState.End;
                    clearThumbnails();
                    return;
                }

                if (timelineState == TimeLineState.End) {
                    return;
                }

                if (timelineState == TimeLineState.Start) {
                    timelineState = TimeLineState.QueryTimeLine;
                    queryStudyTimeLine(); 
                }
                else if (timelineState == TimeLineState.QueryTimeLine) {
                    if (transition = TimeLineTransition.Success) {
                        timelineState = TimeLineState.LoadThumbs;
                        loadThumbnails(extraInfo);
                    }
                }
            }

            function clearThumbnails() {
                thumbnailDiv.empty();
            }

            function queryStudyTimeLine() {
                var query: Models.QueryOptions = new Models.QueryOptions();

                if (currentPatientID != "")
                    query.PatientsOptions.PatientID = currentPatientID;

                queryArchiveService.ElectStudyTimeLineInstances(query).success(function (data, status) {
                    for (var i = 0; i < data.Series.length; i++) {
                        var series = dataService.get_Series(data.Series[i].SeriesInstanceUID);

                        if (series == null) {
                            dataService.add_series(data.Series[i]);
                        }
                    }
                    transitionState(TimeLineTransition.Success, data);
                }).error(function (error) {
                    transitionState(TimeLineTransition.Failure, error);
                });
            }

            function loadThumbnails(data) {
                var totalHeight: number = $(elem).height();
                var cellHeight: number = totalHeight * (80 / 100);
                var thumbDim: number = 100;
                var cellTitleHeight: number;
                var cellThumbHeight: number;
                var cellThumbWidth: number;
                var framesLength: number = data.Instances.length;
                var seriesLength: number = data.Series.length;
                var table: HTMLTableElement;
                var tr: HTMLTableRowElement;
                var td: HTMLTableCellElement;
                var position;

                clearThumbnails();
                if (cellHeight < 60) {
                    thumbDim = 50;
                }
                cellHeight = cellHeight - 5;
                cellTitleHeight = cellHeight / 6;
                cellThumbHeight = cellHeight - cellTitleHeight;
                cellThumbWidth = Math.max(cellTitleHeight, 100);

                if (seriesLength != framesLength) {
                    throw new Error("Instances length differ from series length");
                }

                position = lt.LTHelper.getElementStyle(thumbnailDiv[0], 'position');
                if (position != 'relative') {
                    thumbnailDiv[0].style.position = 'relative';
                }

                if (lt.LTHelper.supportsTouch) {
                    thumbnailDiv[0].style.overflow = 'hidden';
                }
                else {
                    thumbnailDiv[0].style.overflow = 'auto';
                    thumbnailDiv[0].style.overflowY = 'hidden';
                }
                touchScroll(<HTMLDivElement>thumbnailDiv[0]);

                thumbnailDiv[0].style.border = "0px";
                thumbnailDiv[0].style.padding = "0px";
                thumbnailDiv[0].style.padding = "0px";
                thumbnailDiv[0].style.margin = "0px";

                table = <HTMLTableElement>document.createElement('table');
                table.id = "table_" + UUID.generate();
                table.border = "0px";
                table.cellSpacing = "0px";
                table.cellPadding = "0px";
                table.width = "100%";
                table.style.width = '100%';
                table.style.height = '100%';
                table.style.padding = "0px";
                table.style.margin = "0px";
                table.style.borderCollapse = 'separate';
                table.className = 'timeLineTable';

                tr = <HTMLTableRowElement>document.createElement('tr');
                for (var instanceIndex = 0; instanceIndex < framesLength; instanceIndex++) {
                    var frame = seriesManagerService.get_activeCellFrame();

                    if (!frame)
                        continue;

                    if (angular.isDefined(frame.Instance)) {
                        var td: HTMLTableCellElement = document.createElement('td');
                        var process: any;

                        tr.appendChild(td);
                        td.setAttribute('align', 'center');
                        $(td).css('width', cellThumbWidth + "px");
                        td.className = "timeLineCellClass";
                        process = createThumbnailProcess(td, data, instanceIndex, thumbDim, cellHeight, cellTitleHeight, cellThumbWidth, cellThumbHeight);
                        setTimeout(process, 5 * instanceIndex);
                    }
                }
                td = document.createElement('td');
                $(td).css('width', '100%');
                tr.appendChild(td);

                table.appendChild(tr);

                //tr = document.createElement('tr');
                //tr.style.height = "20px";
                //table.appendChild(tr);

                thumbnailDiv.append(table);
            }

            var _studytimeline_timer_event = null;
            var _studytimeline_timer_event_handeled = false;
            var _lastSelectedElement = null;           

            function createThumbnailProcess(td: HTMLTableCellElement, studyTimelineInfo, idx: number, thumbDim: number, cellHeight: number,
                cellTitleHeight: number, cellThumbWidth: number, cellThumbHeight: number) {
                var frame:lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();
                var currentSeriesInstanceUID: string = (<any>frame).Instance.SeriesInstanceUID;

                return function () {
                    var imageUrl; 
                    //var image = studyTimelineInfo.Instances[idx].MRTIImageInfo;
                    var cx = Math.floor(cellHeight);                    
                    
                    var imageUrl = scope.retrieveUrl;

                    imageUrl += '/GetImage?';
                    imageUrl += 'auth=' + encodeURIComponent(authenticationService.authenticationCode);
                    imageUrl += '&instance=' + studyTimelineInfo.Instances[idx].SOPInstanceUID;
                    imageUrl += '&frame=0';
                    imageUrl += '&mime=' + encodeURIComponent('image/jpeg');
                    imageUrl += '&bp=24';
                    imageUrl += '&qf=10';
                    imageUrl += '&cx=' + cx;
                    imageUrl += '&cy=' + cx;

                    td.setAttribute('SeriesInstanceUID', studyTimelineInfo.Instances[idx].SeriesInstanceUID);

                    var imageElement = document.createElement('img');
                    imageElement.setAttribute('id', 'img_' + idx.toString());
                    imageElement.src = imageUrl;
                    imageElement.alt = "loading...";
                    imageElement.title = studyTimelineInfo.Series[idx].Description || studyTimelineInfo.Series[idx].Modality;
                    var thumbSeriesInstanceUID = studyTimelineInfo.Series[idx].InstanceUID;

                    if (thumbSeriesInstanceUID == currentSeriesInstanceUID) {
                        td.style.border = '3px solid #5C880C';
                        _lastSelectedElement = td;
                    }
                    else {
                        td.style.border = '3px solid #000000';
                    }
                                        
                    imageElement.style.maxHeight = "100%";
                    imageElement.style.maxWidth = "100%";

                    imageElement.setAttribute('SeriesInstanceUID', studyTimelineInfo.Instances[idx].SeriesInstanceUID);

                    imageElement.addEventListener('touchstart', function (e) {
                        if (e.preventDefault)
                            e.preventDefault();
                        else
                            event.returnValue = false;
                        _studytimeline_timer_event_handeled = false;
                        window.clearInterval(_studytimeline_timer_event);
                        _studytimeline_timer_event = window.setInterval(function (tmr_event) {
                            _studytimeline_timer_event_handeled = true;
                            window.clearInterval(_studytimeline_timer_event);
                            appendCell(e.target);
                        }, 1000);
                    }, false);

                    imageElement.addEventListener('touchend', function (e) {
                        if (e.preventDefault)
                            e.preventDefault();
                        else
                            event.returnValue = false;
                        window.clearInterval(_studytimeline_timer_event);
                        if (!_studytimeline_timer_event_handeled) {
                            _studytimeline_timer_event_handeled = true;
                            replaceActiveCell(e.target);
                        }
                    });

                    imageElement.addEventListener('MSGestureHold', function (e) {
                        if (e.preventDefault)
                            e.preventDefault();
                        else
                            event.returnValue = false;
                        appendCell(e.target);
                    }, false);

                    imageElement.addEventListener("contextmenu", function (e) {
                        if (e.preventDefault)
                            e.preventDefault();
                        else
                            event.returnValue = false;
                        appendCell(e.target);
                    }, false);

                    imageElement.addEventListener('click', function (e:MouseEvent) {
                        replaceActiveCell(e.target);
                    }, false);

                    {
                        var divThumb = document.createElement('div');

                        divThumb.appendChild(imageElement);
                        var ahref = <any>document.createElement('div');

                        ahref.href = "#";
                        ahref.setAttribute('SeriesInstanceUID', studyTimelineInfo.Instances[idx].SeriesInstanceUID);
                        ahref.setAttribute('draggable', 'true');
                        ahref.appendChild(divThumb);
                        ahref.addEventListener("dragstart", function (e) {
                            e.dataTransfer.effectAllowed = 'copy';
                            e.dataTransfer.setData('Text', this.getAttribute('SeriesInstanceUID'));
                        }, false);

                        td.appendChild(ahref);
                    }

                    {
                        var divTitle = document.createElement('div');
                        var p = document.createElement("P");
                        var date = studyTimelineInfo.Series[idx].Date;
                        var LabelText: string;
                        var text;

                        if ((!date || date.length == 0) && studyTimelineInfo.Studies)
                            date = studyTimelineInfo.Studies[0].Date;

                        if (date && date.length > 0) {
                            date = Utils.dateFormatter(date, dateFormat);
                        }

                        p.style.fontFamily = "Arial, Helvetica, sans-serif";
                        p.style.fontSize = "xx-small";
                        p.style.verticalAlign = "text-top";
                        p.style.textAlign = "center";
                        p.style.padding = "0px";
                        p.style.margin = "0px";
                        p.style.whiteSpace = "nowrap";
                        LabelText = "[" + studyTimelineInfo.Series[idx].Modality + "]";
                        if (date && date.length > 0) {
                            LabelText += " " + date;
                        }                       
                        text = document.createTextNode(LabelText);
                        p.appendChild(text);
                        divTitle.appendChild(p)
                        divTitle.title = LabelText;
                        divTitle.style.width = cellHeight + "px";
                        divTitle.style.height = cellTitleHeight + "px";
                        divTitle.style.color = "#FFFFFF";
                        divTitle.style.padding = "0px";
                        divTitle.style.margin = "0px";
                        divTitle.style.overflow = "hidden";
                        divTitle.style.border = "0px";

                        td.appendChild(divTitle);
                    }
                }
            }

            function touchScroll(div: HTMLDivElement) {
                if (lt.LTHelper.supportsTouch) {
                    //div.addEventListener('touchstart', function (e) { touchstart(e); }, false);
                    //div.addEventListener('touchmove', function (e) { touchmove(e); }, false);
                }
                else {

                    //div.addEventListener('MSPointerDown', function (e) { mouseStart(e); }, true);
                    (<any>div).onselectstart = function () { return false; };
                    //div.addEventListener('mousedown', function (e) { mouseStart(e);; }, true);
                    //div.addEventListener('mousemove', function (e) { mousemove(e); }, true);
                    //div.addEventListener('mouseup', function (e) { mouseEnd(e) }, true);
                    //div.addEventListener('MSPointerUp', function (e) { mouseEnd(e) }, true);

                }
            }

            var mouseDown: boolean;

            function hilightSeries(seriesInstanceUID: string) {
                $(".timeLineCellClass").each(function (i) {
                    if (seriesInstanceUID == this.getAttribute('SeriesInstanceUID')) {
                        _lastSelectedElement = this;
                        this.style.border = '3px solid #5C880C';
                    }
                    else {
                        this.style.border = '3px solid #000000';
                    }
                });
            }

            function replaceActiveCell(target) {
                var seriesInstanceUID: string = '';

                if (null != _lastSelectedElement) 
                    _lastSelectedElement.style.border = '3px solid #000000';

                _lastSelectedElement = target.parentNode.parentNode.parentNode;
                _lastSelectedElement.style.border = '3px solid #5C880C';

                if (lt.LTHelper.browser == lt.LTBrowser.opera) {
                    //
                    // in opera, this is used to refresh the td, not repainted automatically
                    //
                    $(_lastSelectedElement).fadeOut(0).fadeIn(0);
                }

                seriesInstanceUID = target.getAttribute('SeriesInstanceUID');
                //scope.replaceCell({ seriesInstanceUID: seriesInstanceUID });
            }

            function appendCell(target) {
                var seriesInstanceUID: string = '';

                if (null != _lastSelectedElement)
                    _lastSelectedElement.style.border = '3px solid #000000';

                _lastSelectedElement = target.parentNode.parentNode.parentNode;
                _lastSelectedElement.style.border = '3px solid #5C880C';

                if (lt.LTHelper.browser == lt.LTBrowser.opera) {
                    //
                    // in opera, this is used to refresh the td, not repainted automatically
                    //
                    $(_lastSelectedElement).fadeOut(0).fadeIn(0);
                }

                seriesInstanceUID = target.getAttribute('SeriesInstanceUID');
                scope.appendCell({ seriesInstanceUID: seriesInstanceUID });
            }
        }
    };
}]);