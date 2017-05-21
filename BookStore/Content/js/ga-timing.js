function TrackTiming(category, variable, opt_label) {
    this.category = category;
    this.variable = variable;
    this.label = opt_label ? opt_label : this.category;
    this.sTime;
    this.eTime;
    return this;
}

TrackTiming.prototype.startTime = function() {
    this.sTime = new Date().getTime();
    return this;
}

TrackTiming.prototype.endTime = function() {
    this.eTime = new Date().getTime();
    return this;
}

TrackTiming.prototype.send = function(time) {
    if (typeof(_gaq) == 'undefined') {
        return false;
    }
    var timeSpent = typeof time == 'undefined' ? this.eTime - this.sTime : time;
    _gaq.push(['_trackTiming', this.category, this.variable, timeSpent, this.label, 100]);
    return this;
}

function TrackTimingLoadJs(url, callback, tt, async) {
    var js = document.createElement('script');
    js.type = "text/javascript";
    js.async = async !== undefined ? async : true;
    js.src = url;
    js.onload = callback;
    var s = document.getElementsByTagName('script')[0];
    tt.startTime();
    js.tt = tt;
    s.parentNode.insertBefore(js, s);
}

function TrackTimingCallback(event) {
    var e = event || window.event;
    var target = e.target ? e.target : e.srcElement;
    target.tt.endTime().send();
    // Library has loaded. Now you can use it.
}