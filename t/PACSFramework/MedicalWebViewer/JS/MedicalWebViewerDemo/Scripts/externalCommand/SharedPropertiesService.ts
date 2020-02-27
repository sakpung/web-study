// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// <reference path="../app.ts" />

class SharedPropertiesService {

    private _autoMode: boolean;
    private _externalControlMode: boolean;
    private _authenticationToken: string;
    private _port: number;
    private _polling: boolean;

    constructor() {
        this._autoMode = false;
        this._externalControlMode = false;
        this._authenticationToken = '';
        this._port = 0;
        this._polling = true;
    }

    public GetExternalControlMode(): boolean {
        return this._externalControlMode;
    }

    public SetExternalControlMode(externalControlMode: boolean) {
        this._externalControlMode = externalControlMode;
    }

    public GetAutoMode(): boolean {
        return this._autoMode;
    }

    public SetAutoMode(autoMode: boolean) {
        this._autoMode = autoMode;
    }

    public GetToken(): string {
        return this._authenticationToken
    }

    public SetToken(token: string) {
        this._authenticationToken = token;
    }

    public GetPort(): number {
        return this._port;
    }

    public SetPort(port: number) {
        this._port = port;
    }

    public GetPolling(): boolean {
        return this._polling;
    }

    public SetPolling(polling: boolean) {
        this._polling = polling;
    }
}

services.service('sharedPropertiesService', SharedPropertiesService);