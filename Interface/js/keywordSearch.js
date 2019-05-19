import { displayItem } from './functions.js'
$(document).ready(() => {
    $(".barra_pesq").keypress((event) => {
        let keyword = $(".barra_pesq").val();
        axios.get(`http://localhost:5000/api/itemConsulting/key/?palavra=${keyword}`)
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
                    items.forEach(item => displayItem(item, keyword));
                }
            })
            .catch(err => console.log(err));
    });
});