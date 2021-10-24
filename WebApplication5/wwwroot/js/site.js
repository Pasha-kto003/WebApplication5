// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
	$('[data-toggle="tooltip"]').tooltip()
});

$('body').on('click', '.password-checkbox', function () {
	if ($(this).is(':checked')) {
		$('#password-input').attr('type', 'text');
	} else {
		$('#password-input').attr('type', 'password');
	}
});

document.addEventListener('DOMContentLoaded', function () {
    let banner = document.getElementById('banner-wrapper');
    let devLayer = banner.querySelector('.dev');
    let delta = 0;
    banner.addEventListener('mousemove', function (e) {
        delta = ((e.pageX - banner.getBoundingClientRect().left) - banner.offsetWidth / 2) * 0.5;
        devLayer.style.width = (e.pageX - banner.getBoundingClientRect().left) + 200 + delta + 'px';
    });
})