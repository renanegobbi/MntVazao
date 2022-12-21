(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            // 32x32 favicon
            var linkIcon32 = document.createElement('link');
            linkIcon32.type = 'image/png';
            linkIcon32.rel = 'icon';
            linkIcon32.href = '/swagger/resources/favicon-32x32.png';
            linkIcon32.sizes = '32x32';
            document.getElementsByTagName('head')[0].appendChild(linkIcon32);

            // 16x16 favicon
            var linkIcon16 = document.createElement('link');
            linkIcon16.type = 'image/png';
            linkIcon16.rel = 'icon';
            linkIcon16.href = '/swagger/resources/favicon-16x16.png';
            linkIcon16.sizes = '16x16';
            document.getElementsByTagName('head')[0].appendChild(linkIcon16);

            // Cria o botão de retorno da documentação para a home
            var img = document.querySelector("#swagger-ui > section > div.topbar > div > div > a");
            img.remove();
            var btn = document.createElement('button');
            btn.setAttribute("id", "btnVoltar");
            var ancora = document.createElement('a');
            ancora.setAttribute("href", "/Home/Graficos");
            btn.appendChild(ancora);
            var parser = new DOMParser();
            var svgStr = '<svg id="leftArrow" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="long-arrow-alt-left" class="svg-inline--fa fa-long-arrow-alt-left fa-w-14" role="img" viewBox="0 0 448 512"><path fill="currentColor" d="M134.059 296H436c6.627 0 12-5.373 12-12v-56c0-6.627-5.373-12-12-12H134.059v-46.059c0-21.382-25.851-32.09-40.971-16.971L7.029 239.029c-9.373 9.373-9.373 24.569 0 33.941l86.059 86.059c15.119 15.119 40.971 4.411 40.971-16.971V296z"></path></svg>';
            var doc = parser.parseFromString(svgStr, "image/svg+xml");
            ancora.appendChild(doc.all[0]);
            var elementoPai = document.querySelector('#swagger-ui > section > div.topbar > div > div');
            var referencia = document.querySelector('#swagger-ui > section > div.topbar > div > div > form');
            var elementoInserido = elementoPai.insertBefore(btn, referencia);

            var span = document.createElement('span');
            span.setAttribute("id", "btnHome");
            span.innerHTML = 'Home';
            fath = document.querySelector('#btnVoltar > a');
            fath.appendChild(span);

            // Altera para o português a frase de seleção da versão
            var txtSelectVersion = document.querySelector("#swagger-ui > section > div.topbar > div > div > form > label > span");
            txtSelectVersion.innerHTML = "Selecione a versão";
        });
    });
})();