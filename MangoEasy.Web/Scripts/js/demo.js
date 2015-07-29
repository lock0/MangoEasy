var Demo = {
    viewModel: {
        Voice: {
            localId: ko.observable(''),
            serverId: ko.observable('')
        },
        Tips: ko.observable(''),
        RecordState: ko.observable(0),
        Orders: ko.observableArray()
    }
};
Demo.viewModel.profitStatus = ko.computed({
    read: function () {
        return Demo.viewModel.RecordState() > 0 ? "btn btn-danger btn-block" : "btn btn-default btn-block";
    }
});

Demo.viewModel.Record = function () {
    if (Demo.viewModel.RecordState() == 0) {
        wx.startRecord();
        Demo.viewModel.Tips("正在录音");
        Demo.viewModel.RecordState(1);
    } else {
        wx.stopRecord({
            success: function (res) {
                Demo.viewModel.Tips("已停止");
                Demo.viewModel.RecordState(0);
                Demo.viewModel.Voice.localId(res.localId);
                Demo.viewModel.UploadRecord();
            }
        });
    }
};
Demo.viewModel.UploadRecord = function () {
    Demo.viewModel.Tips("准备上传");
    //开始上传
    wx.uploadVoice({
        localId: Demo.viewModel.Voice.localId(), // 需要上传的音频的本地ID，由stopRecord接口获得
        isShowProgressTips: 1, // 默认为1，显示进度提示
        success: function (res) {
            Demo.viewModel.Voice.serverId(res.serverId); // 返回音频的服务器端ID
            Demo.viewModel.Tips('上传语音成功，serverId 为' + res.serverId);
            Demo.viewModel.DowloadRecord();
        }
    });
};

Demo.viewModel.DowloadRecord = function () {
    Demo.viewModel.Tips('正在下载语音至服务器');
    $.get('http://api.mangoeasy.com/api/Token/', { appid: 'wx990c1d301ce34a46' }, function (token) {
        var model = {
            Token: token,
            MediaId: Demo.viewModel.Voice.serverId(),
        };
        $.post('/api/Order/', model, function (result) {
            if (!result.Error) {
                Demo.viewModel.Tips('完成');
                Demo.viewModel.Refresh();
            } else {
                Demo.viewModel.Tips(result.Message);
            }
        });
    });
};
Demo.viewModel.Refresh = function() {
    $.get('/api/Order/', function (orders) {
        ko.mapping.fromJS(orders, {}, Demo.viewModel.Orders);
    });
};

//Demo.viewModel.EndRecord = function () {
//    wx.stopRecord();
//    Demo.viewModel.Tips("停止录音");
//};

//wx.ready(function () {
//    // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
//    $('#start').click(function () {
//        wx.startRecord();
//    });
//    $('#end').click(function () {
//        wx.stopRecord({
//            success: function (res) {
//                voice.localId = res.localId;
//            }
//        });

//    });
//    $('#playvoice').click(function () {
//        if (voice.localId == '') {
//            alert('请先使用 startRecord 接口录制一段声音');
//            return;
//        }
//        wx.playVoice({
//            localId: voice.localId
//        });
//    });
//    $('#uploadvoice').click(function () {
//        if (voice.localId == '') {
//            alert('请先使用 startRecord 接口录制一段声音');
//            return;
//        }
//        wx.uploadVoice({
//            localId: voice.localId, // 需要上传的音频的本地ID，由stopRecord接口获得
//            isShowProgressTips: 1, // 默认为1，显示进度提示
//            success: function (res) {
//                alert('上传语音成功，serverId 为' + res.serverId);
//                voice.serverId = res.serverId; // 返回音频的服务器端ID
//            }
//        });
//    });
//});


$(function () {
    ko.applyBindings(Demo);
    Demo.viewModel.Refresh();
    $(document).ajaxSend(function (e, xhr, settings) {
        xhr.setRequestHeader('Authorization', "YXBwaWQ9OTIwZjQyZGMtOTA1Mi00NDc0LWE0YzktNjgzNTYzNzQ0Y2QzJnNpZ25hdHVyZT0yYzhjY2I3MTI4MzVlZTI4NDE3YWEyOTIxODE3OTBkZTAyMTQ0M2EzJnJhbmRvbT02NTQzMjE=");
    });
    var model = {
        url: location.href,
        appid: 'wx990c1d301ce34a46',
        jsApiList: 'startRecord,stopRecord,playVoice,uploadVoice'
    };
    $.get('http://api.mangoeasy.com/api/JsApiConfig/', model, function (result) {
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: result.AppId, // 必填，公众号的唯一标识
            timestamp: result.Timestamp, // 必填，生成签名的时间戳
            nonceStr: result.NonceStr, // 必填，生成签名的随机串
            signature: result.Signature,// 必填，签名，见附录1
            jsApiList: result.JsApiList // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
    });

});

