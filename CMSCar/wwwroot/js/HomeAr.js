$.ajax({
    url: '/api/HomeApi/GetWhyUs',
    success: function (result) {
        var res = "";
        $.each(result, function (i, v) {
            res = res + ' <div class="col-md-4 col-xs-12"><div class="new_service"><img class="" src="/Images/WhyUs/' + v.imagePath + '"><div class="new_service_wrap"><a class="new_service_link" href="/Home/WhyUs"> <h2 class="new_service_head">' + v.nameAr + '</h2></a><div class="new_service_text"><p>' + v.descrptionAr+'</p></div> </div><a href="#" class="new_service_more"> المزيد <i class="fa fa-caret-left" aria-hidden="true"></i></a> </div> </div>';
        })
        $("#Div_WhyUs").html(res);
    }
});
$.ajax({
    url: '/api/HomeApi/GetTypeCar',
    success: function (result) {
        var res = "";
        $.each(result, function (i, v) {
            res = res + '<div class="col col-md-2 col-6 brand"><a href="/Main/Cars/'+v.id+'"><img src="/Images/CarType/' + v.imagePath + '">' + v.nameAr + '</a></div>';
        })
        $("#Div_TypeCar").html(res);
    }
});
$.ajax({
    url: '/api/HomeApi/GetBanks',
    success: function (result) {
        var res = "";
        $.each(result, function (i, v) {
            res = res + '<div class="col-md-2"><img src="/Images/FininceSide/' + v.imagePath + '"></div>';
        })
        $("#GetBanks").html(res);
    }
});
$.ajax({
    url: '/api/HomeApi/GetCar',
    success: function (result) {
        var res = "";
        $.each(result, function (i, v) {
            res = res + '<div class="car"><a data-toggle="tooltip" data-placement="left" title="Add To Favorait" href="#" class="addToFavLink  "><i class="far fa-heart"></i></a><a href="#"><div class="img_wrap"><img src="/Images/Car/' + v.showImage + '" alt="' + nameAr + '"></div><h3>' + nameAr + '</h3> <hr><ul class="shortDesc"><li>' + v.descriptionAr + '</li><li class="car_placeHolder"></li></ul> <div class="car_price ">' + v.priceBeforeDiscount + '</div></a></div>';
        })
        $("#Div_Car").html(res);
    }
});
