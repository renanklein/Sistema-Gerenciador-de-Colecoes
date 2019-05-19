import {displayItem} from  './functions.js';

export const getElement = (seletor, nome_seletor, route) => {
    $(seletor).click((event) => {
        event.preventDefault();
        if ($(".alert")) {
            $(".alert").remove();
        }
        $("th").each((i, elem) => {
            elem.style.color = "#212529";
        })
        $("tbody").children("tr").each((i, tr) => {
            tr.remove();
        });
        $("td").each((i, elem) => {
            elem.remove();
        });
        axios.get(`http://localhost:5000/api/itemConsulting/${route}`)
            .then((resp) => {
                $("th").filter(`:contains(${nome_seletor})`).css('color', '#2b71e2');
                let items = resp.data;
                items.forEach(item => displayItem(item));
            });
    });
}

$(document).ready(() => {
    getElement("#nome", 'Nome', 'name');
    getElement("#categoria", 'Categoria', 'categoria');
    getElement("#autor", 'Autor', 'autor');
    getElement("#disponivel",'Status',"Disponivel")
    getElement("#emprestado",'Status',"Emprestado")
});


