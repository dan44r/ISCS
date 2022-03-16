function onlyDigits(e, decReq) {
    var key = ((navigator.appName == 'Microsoft Internet Explorer')) ? window.event.keyCode : e.which;
    var obj = ((navigator.appName == 'Microsoft Internet Explorer')) ? event.srcElement : e.target;
    var isNum = (key > 47 && key < 58) ? true : false;
    var dotOK = (key == 46 && decReq == 'decOK' && (obj.value.indexOf(".") < 0 || obj.value.length == 0)) ? true : false;
    if (key < 32)
        return true;
    return (isNum || dotOK);
}

function onlyCodeAZ09(e) {

    var key = ((navigator.appName == 'Microsoft Internet Explorer')) ? window.event.keyCode : e.which;
    var obj = ((navigator.appName == 'Microsoft Internet Explorer')) ? event.srcElement : e.target;
    var isAlphaNum = (key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) ? true : false;
    var splOK = (key == 95 && (obj.value.indexOf(".") < 0 || obj.value.length == 0)) ? true : false;
    if (key < 32)
        return true;
    return (isAlphaNum || splOK);
}