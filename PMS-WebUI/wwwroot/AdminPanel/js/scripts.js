document.addEventListener("DOMContentLoaded", function () {
    var loading = document.getElementById('loading');
    var content = document.querySelector('.admin-container');
    loading.style.display = 'block';
    content.classList.add('hidden');

    window.onload = function () {
        setTimeout(function () {
            loading.style.display = 'none';
            content.classList.remove('hidden');
        }, 1000); // Yükleme saniyesi
    };
});

document.getElementById('loadContent').addEventListener('click', function () {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://api.example.com/data', true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            document.getElementById('content').innerHTML = xhr.responseText;
        }
    };
    xhr.send();
});