var arr_timer = {};
const timer = {};

var addtimer = function(cb , delay){
    setInterval(cb, delay)
}

var deletetimer = function(cb , delay){
    setTimeout(function(){
        if (arr_timer[cb.name]) {
            clearTimeout(arr_timer[cb.name])
            arr_timer[cb.name] = null
        }
    }, delay)
}
timer.AddTime = function(cb , delay, disposetime){

    arr_timer[cb.name] = setInterval(cb, delay)
    if(disposetime) {
        deletetimer(cb,disposetime)
    }
}
// var temptimer = setInterval(function(){
//     console.log("1111111111")
// }, 5000)


// function stopInterval(){
//     clearTimeout(temptimer);
//     //myInterval.unref();
//    }
// setTimeout(stopInterval,50000);

var tempFun = function(){
    console.log('test')
}

var test = function(fun){
    var obj = {}
    obj[fun.name] = fun
    console.log(obj)
}

timer.AddTime(tempFun, 1000, 5000)