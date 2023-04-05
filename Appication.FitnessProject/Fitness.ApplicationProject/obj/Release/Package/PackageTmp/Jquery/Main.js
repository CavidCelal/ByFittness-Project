

var BtnLogin = document.getElementById('BtnLogin')
var LoginBtn = document.getElementById('LoginBtn')
function Mesaj() {
    var KullaniciEmail = document.getElementById('KullaniciEmail').value;
    var Sifre = document.getElementById('Sifre').value;
    if (KullaniciEmail === '' || Sifre === '') {
        ShowAlert('info', 'Hata', 'Her iki alanı doldurun');
    }
    else {
        $ajax({
            url: "/Account/Login",
            success: function (result, e, f) {
                if (f.status === 200) {
                    if (result != "") {
                        window.location.href = "Account/Login"
                    }
                }
                else {
                    ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
                }
            },
            data: { "KullaniciEmail": KullaniciEmail, "Sifre": Sifre },
            method: "Post"
        }).done(function (result, e, f) {
            var f = result;
        }).fail(function (result, e, f) {
            if (result.status === 500) {
                ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
            }
        }).catch(function (result, e, f) {
            var h = result;
        }).progress(function (result, e, f) {
            var y = result;
        }).finally(function () {
            BtnLogin.removeAttribute("disabled");
            BtnLogin.innerText = "Giriş";
        });
    }
    
   
}

function Login1() {
    if (BtnLogin !== undefined) {

        BtnLogin.setAttribute("disabled", "");
        BtnLogin.innerText = "Giriş yapılıyor...";
        var KullaniciEmail = document.getElementById('KullaniciEmail').value;
        var Sifre = document.getElementById('Sifre').value;
        if (KullaniciEmail === '' || Sifre === '') {
            ShowAlert('info', 'Hata', 'Her iki alanı doldurun');
        }
        else {
            $.ajax({
                url: "/Account/Login",
                success: function (result, e, f) {
                    if (f.status === 200) {
                        if (result != "") {
                            window.location.href = "/Account/Login?TblKullanici";
                        }
                    }
                    else {
                        ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
                    }
                },
                //data: { "Username": Username, "Password": Password },
                //method: "POST"
            }).done(function (result, e, f) {
                var f = result;
            }).fail(function (result, e, f) {
                if (result.status === 500) {
                    ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
                }
            }).catch(function (result, e, f) {
                var h = result;
            }).progress(function (result, e, f) {
                var y = result;
            }).finally(function () {
                BtnLogin.removeAttribute("disabled");
                BtnLogin.innerText = "Giriş";
            });
        }
    }

}
//function Login() {
//    if (BtnLogin !== undefined) {

//        BtnLogin.setAttribute("disabled", "");
//        BtnLogin.innerText = "Giriş yapılıyor...";
//        var KullaniciAdi = document.getElementById('TxtUsername').value;
//        var Sifre = document.getElementById('TxtPassword').value;
//        if (TxtUsername === '' || Sifre === '') {
//            ShowAlert('info', 'Hata', 'Her iki alanı doldurun');
//        }
//        else {
//            $.ajax({
//                url: "/Kullanici/Index",
//                success: function (result, e, f) {
//                    if (f.status === 200) {
//                        if (result != "") {
//                            window.location.href = "/Kullanici/Index";
//                        }
//                    }
//                    else {
//                        ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
//                    }
//                },
//                data: { "Username": Username, "Password": Password },
//                method: "POST"
//            }).done(function (result, e, f) {
//                var f = result;
//            }).fail(function (result, e, f) {
//                if (result.status === 500) {
//                    ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
//                }
//            }).catch(function (result, e, f) {
//                var h = result;
//            }).progress(function (result, e, f) {
//                var y = result;
//            }).finally(function () {
//                BtnLogin.removeAttribute("disabled");
//                BtnLogin.innerText = "Giriş";
//            });
//        }
//    }

//}

function GetLoginUserDetail() {
    $.ajax({
        url: "/Api/GetLoginUserDetail",
        success: function (result, e, f) {
            if (f.status === 200) {
                var LblNameSurname = document.getElementById('LblNameSurname');
                LblNameSurname.innerHTML = "<b>" + result.Ad + " " + result.Soyad + "</b>";
                var LblTitle = document.getElementById('LblTitle');
                LblTitle.innerText = result.Unvan;
                var LblWelcome = document.getElementById('LblWelcome');
                LblWelcome.innerText = "Merhaba " + result.Ad + " " + result.Soyad;
            }
            else {
                ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
            }
        },
        method: "GET"
    }).done(function (result, e, f) {
        var f = result;
    }).fail(function (result, e, f) {
        if (result.status === 500) {
            ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
        }
    }).catch(function (result, e, f) {
        var h = result;
    }).progress(function (result, e, f) {
        var y = result;
    });

}

//success - error - warning - info - question
function ShowAlert(picon, ptitle, ptext) {

    Swal.fire({
        icon: picon,
        title: ptitle,
        text: ptext
    });

}

function Login1() {
    if (BtnLogin !== undefined) {

        BtnLogin.setAttribute("disabled", "");
        BtnLogin.innerText = "Giriş yapılıyor...";
        var KullaniciEmail = document.getElementById('KullaniciEmail').value;
        var Sifre = document.getElementById('Sifre').value;
        if (KullaniciEmail === '' || Sifre === '') {
            ShowAlert('info', 'Hata', 'Her iki alanı doldurun');
        }
        else {
            $.ajax({
                url: "/Account/Login",
                success: function (result, e, f) {
                    if (f.status === 200) {
                        if (result != "") {
                            window.location.href = "/Account/Login?";
                        }
                    }
                    else {
                        ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
                    }
                },
                //data: { "Username": Username, "Password": Password },
                //method: "POST"
            }).done(function (result, e, f) {
                var f = result;
            }).fail(function (result, e, f) {
                if (result.status === 500) {
                    ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
                }
            }).catch(function (result, e, f) {
                var h = result;
            }).progress(function (result, e, f) {
                var y = result;
            }).finally(function () {
                BtnLogin.removeAttribute("disabled");
                BtnLogin.innerText = "Giriş";
            });
        }
    }

}