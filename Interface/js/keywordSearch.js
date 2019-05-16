$(document).ready(() => {
    $(".barra_pesq").keyup((event) => {
        let keyword = $(".barra_pesq").val().replace(' ', '+');
        console.log(keyword);
        axios.get(`http://localhost:5000/api/itemConsulting/key?chave=${keyword}`)
            .then((resp) => {
                $("th").each((i, elem) => {
                    elem.style.color = "#212529";
                })
                $("td").each((i, elem) => {
                    elem.remove();
                });
                let items = resp.data;
                if (items.length === 0) {
                    $(".alert").remove();
                    $("#table").prepend('<div class="alert alert-danger m-4">Nenhum item encontrado</div>');
                } else {
                    $(".alert").remove();
                    items.forEach(item => {
                        let html = `<tr>
                            <td>${item.tipo}</td>
                            <td>${item.nome}</td>
                            <td>${item.categoria}</td>
                            <td>${item.autor}</td>
                            <td>${item.status}</td>
                            <td><a href="html/emprestar.html?id=${item.itemId}">Emprestar</a></td>
                            </tr>`;
                        $('table').append("<tr>").append(html).hide().fadeIn(500);
                    });
                }
            })
            .catch(err => console.log(err));
    });
});