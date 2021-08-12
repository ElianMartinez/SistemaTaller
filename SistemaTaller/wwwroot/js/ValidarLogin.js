﻿jQuery(document).ready(($) => {
    $("#username").focus();
    $("#btnEnter").on("click", function (e) {
        e.preventDefault();
        if ($("#username").val() != "" && $("#password").val() != "") {
            Validar($("#username").val().trim(), $("#password").val().trim());
        } else {
            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Los campos están vacios',
            
            })
        }
    })
});

function Validar(usuario, clave) {
    var record = {
        Nombre: usuario,
        Clave: clave
    };

    $.ajax({
        url: '/Usuarios/GetCreUsuarios',
        async: true,
        type: 'POST',
        data: record,
        beforeSend: function (xhr, opts) {
            $("#btnEnter").attr('value', 'Loading.....');
        },
        complete: function () {
            $("#btnEnter").attr('value', 'Login');

        },
        success: function (data) {
            console.log(data);
            if (data.status == true) {
                localStorage.setItem("session", "true");
                localStorage.setItem("name", usuario);
                localStorage.setItem("cargo", data.cargo);
                location.href = "/Home/Index";
            } else {
                Swal.fire({
                    icon: 'warning',
                    title: 'Credenciales no validas',
                    text: 'El usuario y/o contraseña están mal',

                })
            }
        },
        error: function (data) {
            Swal.fire({
                icon: 'Error',
                title: 'Ocurrio un error',
                text: data.message,

            })
        }
    })
}