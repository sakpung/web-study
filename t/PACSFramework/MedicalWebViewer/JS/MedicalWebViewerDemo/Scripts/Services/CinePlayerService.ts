// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class CinePlayerService {
    static $inject = ['seriesManagerService', 'eventService'];

    private _seriesManagerService: SeriesManagerService;
    private _eventService: EventService;
    private _seriesInstanceUID: string = "";
    private _cinePlayer: lt.Controls.Medical.CinePlayer;
    private _cell: lt.Controls.Medical.Cell;
    private _updating = false;    
    private _playerStoppedHandle;

    private _fps: number = 30;

    public get fps(): number {
        return this._fps;
    }

    public set fps(value: number) {
        this._fps = value;
        this.updatePlayer();
    }

    private _maxSkip: number = 10;

    public get maxSkip(): number {
        return this._maxSkip;
    }

    public set maxSkip(value: number) {
        this._maxSkip = value;
        this.updatePlayer();
    }

    public get isPlaying(): boolean {
        if (this._cinePlayer == null)
            return false;
        return this._cinePlayer.isPlaying;
    }

    public _currentFrame: number = 1;

    public get currentFrame(): number {
        return this._currentFrame;
    }

    public set currentFrame(value: number) {
        this._currentFrame = value;
        this.updatePlayer();
    }

    private _loop: boolean = true;

    public get loop(): boolean {
        return this._loop;
    }

    public set loop(value: boolean) {
        this._loop = value;
        this.updatePlayer();
    }

    private _direction: string = "Forward";

    public get direction(): string {
        return this._direction;
    }

    public set direction(value: string) {

        this._direction = value;
        this.updatePlayer();
    }

    public set directionFromPlayingDirection(playingDirection: lt.Controls.Medical.PlayingDirection) {
        switch (playingDirection) {
            case lt.Controls.Medical.PlayingDirection.forward:
                this.direction = "Forward";
                break;
            case lt.Controls.Medical.PlayingDirection.backward:
                this.direction = "Backward";
                break;
            case lt.Controls.Medical.PlayingDirection.sweep:
                this.direction = "Sweep";
                break;
            case lt.Controls.Medical.PlayingDirection.shuffle:
                this.direction = "Shuffle";
                break; 
        }
    }

    private _frameChanged: Function;

    public set_frameChanged(frameChanged: Function) {
        if (angular.isDefined(frameChanged)) {
            this._frameChanged = frameChanged;
        }
        return this._frameChanged;
    }

    constructor(seriesManagerService: SeriesManagerService, eventService: EventService) {
        this._seriesManagerService = seriesManagerService;
        this._eventService = eventService;
    }

    public attachCell(cell: lt.Controls.Medical.Cell) {
        var wasPlaying: boolean;

        if (this._cinePlayer != null) {
            if (this._cinePlayer.isPlaying) {
                this.stop();
                wasPlaying = true;
            }
        }
        this._seriesInstanceUID = cell.seriesInstanceUID;
        this._cell = cell;
        this._cinePlayer = this._cell.cinePlayer;//  new lt.Controls.Medical.CinePlayer();
    }

    public get cell(): lt.Controls.Medical.Cell {
        return this._cell;
    }

    public start() {
        if (this._cinePlayer.isPlaying)
            return;

        this.updatePlayer();
        
        this._playerStoppedHandle = this._eventService.subscribe(EventNames.PlayerStopped, this.playerStopped.bind(this));
        this._cinePlayer.add_frameChanged(this.frameChanged.bind(this));
        

        //this._cinePlayer.set_frameChanged



        var count = this._cell.viewer.layout.items.count;
        var index = 0;
        var cell: lt.Controls.Medical.Cell;

        var checkedTickBoxFound = false;
        for (index = 0; index < count; index++) {

            cell = this._cell.viewer.layout.items.get_item(index);

            if (cell.tickBoxes[0].checked) {
                checkedTickBoxFound = true;
                cell.cinePlayer.play();
            }
        }

        if (!checkedTickBoxFound) {
            this._cell.cinePlayer.play();
        }

    }

    public stop() {
        var count = this._cell.viewer.layout.items.count;
        var index = 0;
        var cell: lt.Controls.Medical.Cell;


        for (index = 0; index < count; index++) {
            cell = this._cell.viewer.layout.items.get_item(index);
            if (cell.cinePlayer.isPlaying) {
                cell.cinePlayer.stop();
            }
        }
        this._eventService.unsubscribe(this._playerStoppedHandle);

    }

    public first() {
        if (this._cinePlayer.isPlaying)
            return;

        if (this._cell) {
            this._cell.set_currentOffset(0);            
        }
    }

    public last() {
        if (this._cinePlayer.isPlaying)
            return;

        if (this._cell) {
            this._cell.set_currentOffset(this._seriesManagerService.get_maxAllowedStackIndex(this._cell)-1);            
        }
    }

    public previous() {
        if (this._cinePlayer.isPlaying)
            return;
        if (this._cell) {
            this._cell.set_currentOffset(Math.max(this._cell.get_currentOffset() - 1, 0));            
        }
    }

    public next() {
        if (this._cinePlayer.isPlaying)
            return;
        if (this._cell) {
            this._cell.set_currentOffset(Math.min(this._cell.get_currentOffset() + 1, this._seriesManagerService.get_maxAllowedStackIndex(this._cell)));            
        }
    }

    private updateCellCine(cell: lt.Controls.Medical.Cell) {
        var fps = this._fps;
        var maxSkip = this._maxSkip;
        var currentFrame = this._currentFrame;

        if (this._updating) {
            return;
        }

        if (cell == null || cell.cinePlayer == null)
            return;

        this._updating = true;
        if (!this.is_pos_int(fps) || fps == 0) {
            this._fps = cell.cinePlayer.FPS;
        }

        if (!this.is_pos_int(maxSkip)) {
            this._maxSkip = cell.cinePlayer.maxSkip;
        }

        if (!this.is_pos_int(currentFrame) || (currentFrame < 0 || currentFrame > this._seriesManagerService.get_maxAllowedStackIndex(this._cell))) {
            this.currentFrame = this._cell.get_currentOffset() + 1;
        }

        cell.cinePlayer.FPS = fps;
        cell.cinePlayer.maxSkip = maxSkip;
        cell.cinePlayer.loop = this.loop;

        switch (this.direction) {
            case "Forward":
                cell.cinePlayer.direction = lt.Controls.Medical.PlayingDirection.forward;
                break;
            case "Backward":
                cell.cinePlayer.direction = lt.Controls.Medical.PlayingDirection.backward;
                break;
            case "Shuffle":
                cell.cinePlayer.direction = lt.Controls.Medical.PlayingDirection.shuffle;
                break;
            case "Sweep":
                cell.cinePlayer.direction = lt.Controls.Medical.PlayingDirection.sweep;
                break;
        }

        //cell.cinePlayer.currentFrame = this.currentFrame;
        //cell.set_currentOffset(currentFrame - 1);
        this._updating = false;
    }
    
    private updatePlayer() {
         if (this._cell == null)
            return;
        var count = this._cell.viewer.layout.items.count;
        var index = 0;
        var cell: lt.Controls.Medical.Cell;
        var checkedTickBoxFound = false;

        for (index = 0; index < count; index++) {

            cell = this._cell.viewer.layout.items.get_item(index);
            if (cell.tickBoxes[0].checked) {
                checkedTickBoxFound = true;
                this.updateCellCine(cell);
            }
        }

        if (!checkedTickBoxFound) {
            this.updateCellCine(this._cell);
        }

    }

       

    private frameChanged(sender, frame: lt.Controls.Medical.FrameChangedEventArgs) {
        var index = frame.frameIndex;
        var frameIndex = index >= 0 ? index : 0;

        //this._cell.set_currentOffset(frameIndex);
        this._currentFrame = frameIndex;
        if (this._frameChanged) {
            this._frameChanged(frameIndex);
        }
    }

    private playerStopped(event, data) {        
        this._eventService.unsubscribe(this._playerStoppedHandle);          
    }    

    private is_pos_int(value) {
        if ((parseFloat(value) == parseInt(value, 10)) && !isNaN(value)) {
            return parseInt(value, 10) >= 0;
        } else {
            return false;
        }
    }
}

services.service('cinePlayerService', CinePlayerService);