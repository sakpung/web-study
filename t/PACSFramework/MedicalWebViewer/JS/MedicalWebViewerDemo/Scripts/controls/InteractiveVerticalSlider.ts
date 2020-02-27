// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
declare var ss;

class InteractiveVerticalSlider extends lt.Controls.InteractiveService {
    private _scrollBar: HTMLElement;
    private _steps: number;
    private _slider: HTMLElement;
    private _unitSize: number = 0;
    private _currentStep: number = 0;
    private _inMin: boolean = true;
    private _inMax: boolean = false; 
    private _screenY: number = 0;  
    private _isStarted = false;  
    private _currentPosition: lt.LeadPointD;   
    private _workCompleted = null;
    private _stepChanged = null;
   
    constructor(element: HTMLElement, steps: number) {
        super();
        super.set_enableMouseWheel(false);
        this._scrollBar = element;
        this._steps = steps;
        this._slider = document.createElement('div');
        this._slider.className = 'slider';
        this._scrollBar.appendChild(this._slider);

        this.createControl(this._scrollBar, this._scrollBar.parentElement, this._slider);

        if (lt.LTHelper.supportsTouch) {
            this.set_hitTestBuffer(15);                
        }

        this.setupSlider();
        this.startListening();
    }

    public setupSlider() {
        var sliderHeight = this.calculateSliderHeight(this._steps);
        var availableSpace = this._scrollBar.clientHeight - sliderHeight;
        var currentStep: number;

        this._unitSize = availableSpace / Math.max(1, this._steps - 1);  
        currentStep = this.get_currentStep();
        this.set_currentStep(1);
        this._slider.style.height = sliderHeight + "px";
        this._slider.style.position = 'absolute';
        this.set_currentStep(currentStep);      
    }

    private calculateSliderHeight(steps) {
        var scrollHeight = this._scrollBar.clientHeight;
        var allSteps = scrollHeight / (steps==0?1:steps);

        return ((allSteps > 30) ? allSteps : 30);
    }

    public get_isWorking() {
        return this._isStarted;
    }

    public get_currentStep(): number {
        return this._currentStep + 1;
    }

    public set_currentStep(step: number) {
        var offsetTop: number;
        var offsetY;

        if (step <= 0 || step > this._steps) {
            return;
        }

        step = step - 1;
        offsetTop = $(this._scrollBar).offset().top;
        offsetY = (step * this._unitSize) + offsetTop;
        $(this._slider).offset({ top: offsetY });
        this._currentStep = step;
    }

    public updateSteps(steps: number) {
        var oldSteps = this.get_currentStep();

        this._steps = steps;
        this._screenY = 0;
        this._unitSize = 0;
        this._inMin = true;
        this._inMax = false;

        this.setupSlider();
        this.set_currentStep(Math.min(oldSteps, steps));
    }

    public resetSteps(steps: number) {
        this._steps = steps;
        this._screenY = 0;
        this._unitSize = 0;
        this._inMin = true;
        this._inMax = false;

        this.setupSlider();
        this.set_currentStep(1);
    }

    public add_stepChanged(value) {
        this._stepChanged = ss.Delegate.combine(this._stepChanged, value);
    }

    public remove_stepChanged(value) {
        this._stepChanged = ss.Delegate.remove(this._stepChanged, value);
    }

    public add_workCompleted(value) {
        this._workCompleted = ss.Delegate.combine(this._workCompleted, value);
    }

    public remove_workCompleted(value) {
        this._workCompleted = ss.Delegate.remove(this._workCompleted, value);
    }

    public onDragStarted(e: lt.Controls.InteractiveDragStartedEventArgs) {
        if (this._steps <= 1) {
            return;
        }

        if (!isNaN(this._unitSize)) { 
            super.onDragStarted(e); 
            this._isStarted = true;
            this._currentPosition = e.position;         
        }
    }

    public onDragCompleted(e: lt.Controls.InteractiveDragCompletedEventArgs) {
        if (this._isStarted) {            
            this._isStarted = false;
            if (this._workCompleted != null) {
                this._workCompleted(this, null);
            }
        }
    } 

    public onDragDelta(e: lt.Controls.InteractiveDragDeltaEventArgs) {
        if (this._isStarted) {
            var offsetY;
            var newScreenY;
            var deltaY;
            var newPosition;
            var offsetTop;
            var min;
            var max;
            var offsetScroll;
            var currentUnit;
            var eventElementSource:any = e.get_nativeEvent();

            if (eventElementSource.touches != null) {
                eventElementSource = eventElementSource.touches[0];
            }

            offsetY = 0;
            newScreenY = eventElementSource.clientY;
            deltaY = newScreenY - this._screenY;
            newPosition = e.get_position();
            offsetTop = $(this._scrollBar).offset().top;
            min = offsetTop;
            max = (this._scrollBar.clientHeight + offsetTop) - this._slider.clientHeight;

            offsetY = eventElementSource.clientY; 
            offsetScroll = offsetY - min;
            currentUnit = offsetScroll / this._unitSize;

            this._screenY = newScreenY;

            if (deltaY == 0) {
                return;
            }
            if (deltaY > 0) {
                currentUnit = Math.ceil(currentUnit);
            }
            else if (deltaY < 0) {
                currentUnit = Math.floor(currentUnit);
            }
            if (currentUnit < 0) {
                currentUnit = 0;
            }
            if (currentUnit > this._steps - 1) {
                currentUnit = this._steps - 1;
            }

            offsetY = (currentUnit * this._unitSize) + offsetTop;

            if (offsetY <= min) {
                if (this._inMin) {
                    return;
                }
                this._inMin = true;
                offsetY = min;
            }
            else {
                this._inMin = false;
            }
            if (offsetY >= max) {
                if (this._inMax) {
                    return;
                }
                this._inMax = true;
                offsetY = max;
            }
            else {
                this._inMax = false;
            }

            if (this._currentStep != currentUnit) {
                this._currentStep = currentUnit;
                $(this._slider).offset({ top: offsetY });

                if (null !== this._stepChanged) {
                    this._stepChanged(this, new StepChangedEventArgs(this.get_currentStep()));
                }
            }
        }
    }
}

class StepChangedEventArgs extends lt.LeadEventArgs {
    private _newIndex: number;    

    constructor(newIndex: number) {
        super();
        this._newIndex = newIndex;
    }

    public get_newIndex(): number {
        return this._newIndex;
    }

    public set_newIindex(value: number) {
        this._newIndex = value;        
    }
}