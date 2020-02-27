// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Models {
    export class Toolbar {
        private _items: Array<ToolbarItem>;

        public get items(): Array<ToolbarItem> {
            return this._items;
        }

        public set items(value: Array<ToolbarItem>) {
            this._items = value;
        }

        private _name: string;

        public get name(): string {
            return this._name;
        }

        public set name(value: string) {
            this._name = value;
        }

        constructor() {
            this._items = new Array<Models.ToolbarItem>();
        }
    }

    export class ToolbarItem {
        private _id: string;

        public get id(): string {
            return this._id;
        }

        public set id(value: string) {
            this._id = value;
        }

        private _title: string;

        public get title(): string {
            return this._title;
        }

        public set title(value: string) {
            this._title = value;
        }

        private _tooltip: string;

        public get tooltip(): string {
            return this._tooltip;
        }

        public set tooltip(value: string) {
            this._tooltip = value;
        }

        private _caption: string;

        public get caption(): string {
            return this._caption;
        }

        public set caption(value: string) {
            this._caption = value;
        }

        private _type: string;

        public get type(): string {
            return this._type;
        }

        public set type(value: string) {
            this._type = value;
        }

        private _action: string;

        public get action(): string {
            return this._action;
        }

        public set action(value: string) {
            this._action = value;
        }

        private _shortcut: string;

        public get shortcut(): string {
            return this._shortcut;
        }

        public set shortcut(value: string) {
            this._shortcut = value;
        }

        private _cssIconClass: string;

        public get cssIconClass(): string {
            return this._cssIconClass;
        }

        public set cssIconClass(value: string) {
            this._cssIconClass = value;
        }

        private _visible: boolean;

        public get visible(): boolean {
            return this._visible;
        }

        private _disabled: boolean;

        public get disabled(): boolean {
            return this._disabled;
        }

        private _items: Array<ToolbarItem>;

        public get items(): Array<ToolbarItem> {
            return this._items;
        }

        public set items(value: Array<ToolbarItem>) {
            this._items = value;
        }

        constructor() {
            this._items = new Array<Models.ToolbarItem>();
            this._action = '';
            this._cssIconClass = '';
            this._id = '';
            this._title = '';
            this._tooltip = '';
            this._type = '';
            this._visible = true;
        }
    }

    export class ToolbarButton extends Models.ToolbarItem {
        constructor() {            
            super();
            this.type = "button";
        }
    }

    export class ToolbarGroup extends Models.ToolbarItem {
        constructor() {           
            super();
            this.type = "button";
        }
    }
}
