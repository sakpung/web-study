// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module TabTypes {
    export var None: number = -1;
    export var Search: number = 0;
    export var Viewer: number = 1;
    export var UserQueue: number = 2;
    export var Compare: number = 3;
}

module Models {
    export class Tab {

        private _showStudyTimeLine : boolean;

        public get showStudyTimeLine(): boolean {
            return this._showStudyTimeLine;
        }

        public set showStudyTimeLine(value: boolean) {
            this._showStudyTimeLine = value;
        }


        private handle_engine3DData(sender, args, queryArchiveService: QueryArchiveService, query, id, sopInstanceUID: string, optionsService: OptionsService) {

            var engine: lt.Controls.Medical.Object3DEngine = <lt.Controls.Medical.Object3DEngine>sender;
            var renderingMethod = optionsService.get(OptionNames.RenderingMethod);
            renderingMethod = (renderingMethod.indexOf("Hardware") != -1) ? 0 : 1;

            switch (args.type) {

                case lt.Controls.Medical.Requested3DDataType.create3DObject:
                    queryArchiveService.Start3DObject(query, id, renderingMethod, sopInstanceUID).then(function (data) {
                        if (data.data != "Success") {
                            engine.status = lt.Controls.Medical.Object3DStatus.error;
                            engine.errorMessage = data.data.Message ? data.data.Message : data.data;
                        }
                    });
                    break;

                case lt.Controls.Medical.Requested3DDataType.creationProgress:
                    queryArchiveService.CheckProgress(id).then(function (data) {
                        if (isNaN(data.data)) {
                            engine.status = lt.Controls.Medical.Object3DStatus.error;
                            engine.errorMessage = data.data.Message ? data.data.Message : data.data;
                        }
                        else {
                            if (engine.progress != 100) {
                                engine.progress = parseInt(data.data);
                            }
                        }


                    });
                    break;
                case lt.Controls.Medical.Requested3DDataType.keepServerObjectAlive:
                    queryArchiveService.KeepAlive(id);
                    break;
                case lt.Controls.Medical.Requested3DDataType.delete3DObject:
                    queryArchiveService.Close3DImage(id);
                    break;
            }
        };

        private _engineDictionary;


        public DeleteUnusedengine(viewer: lt.Controls.Medical.MedicalViewer) {

            var items: lt.LeadCollection = viewer.layout.get_items();

            var index = 0;
            var length = items.get_count();

            var currentCell: lt.Controls.Medical.LayoutManagerItem;
            var engineID;
            var unusedEngineList = {};
            for (var item in this._engineDictionary) unusedEngineList[item] = this._engineDictionary[item];

            for (index = 0; index < length; index++) {

                currentCell = items.get_item(index);

                engineID = this.getRealId(currentCell.divID);

                // this is the original cell, skip it, cause the enigne hasn't proven that's been used yet.
                if (currentCell.divID == engineID)
                    continue;


                // remove the item from the unsed list, since it's used by this cell.
                delete unusedEngineList[engineID];
            }


            for (var item in unusedEngineList) {

                var engine : lt.Controls.Medical.Object3DEngine = this._engineDictionary[item];
                engine.end();

                delete this._engineDictionary[item];
            }

        }

        public AddnewEngine(id: string, queryArchiveService: QueryArchiveService, query, sopInstanceUID: string, optionsService: OptionsService): lt.Controls.Medical.Object3DEngine {
            var engineID = this.getRealId(id);
            var __this = this;

            if (!this._engineDictionary[engineID]) {
                var engine: lt.Controls.Medical.Object3DEngine = new lt.Controls.Medical.Object3DEngine(engineID);
                this._engineDictionary[engineID] = engine;

                engine.add_request3DData(function (sender, args) {
                    __this.handle_engine3DData(sender, args, queryArchiveService, query, engineID, sopInstanceUID, optionsService);
                });
            }

            return this._engineDictionary[engineID];
        };

        private getRealId(fullID: string) : string {
            var index: number = fullID.lastIndexOf('_');


            var stripEngineID: string = (index == -1 ? fullID : fullID.substr(0, index));

            return stripEngineID;
        }


        public RemoveEngineIfUnused(engineID: string): any {

            engineID = this.getRealId(engineID);
            if (this._engineDictionary[engineID]) {
                this._engineDictionary[engineID] = new lt.Controls.Medical.Object3DEngine(engineID);
            }
            return this._engineDictionary[engineID];
        };





        public get engineDictionary(): any {
            return this._engineDictionary;
        }

        private _title: string;

        public get title(): string {
            return this._title;
        }

        public set title(value: string) {
            this._title = value;
        }

        private _templateUrl: string;

        public get templateUrl(): string {
            return this._templateUrl;
        }

        public set templateUrl(value: string) {
            this._templateUrl = value;
        }

        private _controller: any;

        public get controller(): any {
            return this._controller;
        }

        public set controller(value: any) {
            this._controller = value;
        }        

        private _active: boolean;

        public get active(): boolean {
            return this._active;
        }

        public set active(value: boolean) {
            this._active = value;
        }

        private _id: string;

        public get id(): string {
            return this._id;
        }

        private _type: number;

        public get type(): number {
            return this._type;
        }

        public set type(value: number) {
            this._type = value;
        }

        private _canDelete: boolean;

        public get canDelete(): boolean {
            return this._canDelete;
        }

        public set canDelete(value: boolean) {
            this._canDelete = value;
        }

        private _data: any;

        public get data(): any {
            return this._data;
        }

        public set data(value: any) {
            this._data = value;
        }

        private _visible: boolean;
        private _itemCount: number;

        public get visible(): boolean {
            return this._visible;
        }

        public set visible(value: boolean) {
            this._visible = value;
        }

        public set itemCount(value: number) {
            this._itemCount = value;
        }

        public get itemCount(): number {
            return this._itemCount;
        }

        constructor(id: string) {
            this._id = id;
            this.title = "";
            this.templateUrl = "";
            this.controller = "";
            this.active = false;
            this._type = TabTypes.None;
            this._canDelete = false;
            this._data = {};
            this._visible = true;
            this._itemCount = 0;
            this._engineDictionary = {};
        }
    }
}
