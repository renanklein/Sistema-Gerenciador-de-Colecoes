import { displayItem } from './functions.js';
import { displayPaginateButton } from './pagination.js';
export const getElement = (seletor, nome_seletor, uri) => {
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
        axios.get(uri)
            .then((resp) => {
                if(nome_seletor !== ""){
                    $("th").filter(`:contains(${nome_seletor})`).css('color', '#2b71e2');
                }
                let items = resp.data;
                items.forEach(item => displayItem(item));
                if (resp.headers.paginacao) {
                    let pagination_info = JSON.parse(resp.headers.paginacao);
                    $(".pagination").remove();
                    displayPaginateButton(pagination_info);
                    getElement("#pre", "", `http://localhost:5000/api/item?&pagina=${pagination_info.pagina - 1}&itens=5`);
                    getElement("#pos", "", `http://localhost:5000/api/item?&pagina=${pagination_info.pagina + 1}&itens=5`);
                }else{
                    $(".pagination").remove();
                }
            });
    });
}

$(document).ready(() => {
    getElement("#nome", 'Nome', `http://localhost:5000/api/itemConsulting/name`);
    getElement("#categoria", 'Categoria', `http://localhost:5000/api/itemConsulting/categoria`);
    getElement("#autor", 'Autor', `http://localhost:5000/api/itemConsulting/autor`);
    getElement("#disponivel", 'Status', `http://localhost:5000/api/itemConsulting/Disponivel`)
    getElement("#emprestado", 'Status', `http://localhost:5000/api/itemConsulting/Emprestado`)
});


