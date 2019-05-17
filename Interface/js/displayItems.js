// Para o nome
$(document).ready(() => {
    $("#nome").click((event) => {
        event.preventDefault();
        if ($(".alert")) {
            $(".alert").remove();
        }
        $("th").each((i, elem) => {
            elem.style.color = "#212529";
        })
        $("td").each((i, elem) => {
            elem.remove();
        });
        $("tbody").remove("tr");
        axios.get("http://localhost:5000/api/itemConsulting/name")
            .then((resp) => {
                $("th").filter(":contains('Nome')").css('color', '#2b71e2');
                let items = resp.data;
                items.forEach(item => {
                    let html = `<tr>
                            <td>${item.tipo}</td>
                                <td>${item.nome}</td>
                                <td>${item.categoria}</td>
                                <td>${item.autor}</td>
                                <td>${item.status}</td>
                                </tr>`;
                    if (item.status === "Disponível") {
                        html.concat(`<td><a href="html/emprestar.html?id=${item.itemId}">Emprestar</a></td>`);
                    }
                    $('table').append("<tr>").append(html).hide().fadeIn(500);
                });
            });
    });
});


// Para categoria 


$(document).ready(() => {
    $("#categoria").click((event) => {
        event.preventDefault();
        if ($(".alert")) {
            $(".alert").remove();
        }
        $("th").each((i, elem) => {
            elem.style.color = "#212529";
        })
        $("td").each((i, elem) => {
            elem.remove();
        });
        $("tbody").remove("tr");
        axios.get("http://localhost:5000/api/itemConsulting/categoria")
            .then((resp) => {
                $("th").filter(":contains('Categoria')").css('color', '#2b71e2');
                let items = resp.data;
                items.forEach(item => {
                    let html = `<tr>
                    <td>${item.tipo}</td>
                        <td>${item.nome}</td>
                        <td>${item.categoria}</td>
                        <td>${item.autor}</td>
                        <td>${item.status}</td>
                        </tr>`;
                    if (item.status === "Disponível") {
                        html.concat(`<td><a href="html/emprestar.html?id=${item.itemId}">Emprestar</a></td>`);
                    }
                    $('table').append("<tr>").append(html).hide().fadeIn(500);
                });
            });
    });
});


// Para autor

$(document).ready(() => {
    $("#autor").click((event) => {
        event.preventDefault();
        if ($(".alert")) {
            $(".alert").remove();
        }
        $("th").each((i, elem) => {
            elem.style.color = "#212529";
        })
        
        $("td").each((i, elem) => {
            elem.remove();
        });
        $("tbody").remove("tr");
        axios.get("http://localhost:5000/api/itemConsulting/name")
            .then((resp) => {
                $("th").filter(":contains('Autor')").css('color', '#2b71e2');
                let items = resp.data;
                items.forEach(item => {
                    let html = `<tr>
                    <td>${item.tipo}</td>
                        <td>${item.nome}</td>
                        <td>${item.categoria}</td>
                        <td>${item.autor}</td>
                        <td>${item.status}</td>
                        </tr>`;
                    if (item.status === "Disponível") {
                        html.concat(`<td><a href="html/emprestar.html?id=${item.itemId}">Emprestar</a></td>`);
                    }
                    $('table').append("<tr>").append(html).hide().fadeIn(500);
                });
            });
    });
});