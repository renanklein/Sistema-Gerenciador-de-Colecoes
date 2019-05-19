import { displayItem } from './functions.js';
import { displayPaginateButton } from './pagination.js';

function paginate(seletor, paginate_info) {
    $(seletor).click((event) => {
        event.preventDefault();
        const pagina = paginate_info.pagina;
        let uri = '';
        if (seletor.indexOf("#pre") !== -1) {
            uri = `http://localhost:5000/api/item?&pagina=${pagina - 1}&itens=5`;
        }
        else if (selector.indexOf("#pos") !== -1) {
            uri = `http://localhost:5000/api/item?&pagina=${pagina + 1}&itens=5`;
        }
        axios.get(uri)
            .then((resp) => {
                let items = resp.data;
                console.log(resp.data);
                items.forEach(item => displayItem(item));
            })
            .catch(err => console.log(err));
    })
}
let pagination_info;
$(document).ready(() => {
    if (localStorage.getItem("msg")) {
        $("main").prepend(localStorage.getItem("msg"));
        localStorage.clear();
    }
    axios.get(`http://localhost:5000/api/item?&pagina=1&itens=5`)
        .then(resp => {
            let items = resp.data;
            pagination_info = JSON.parse(resp.headers.paginacao);
            console.log(pagination_info.pagina);
            items.forEach(item => displayItem(item));
            displayPaginateButton(pagination_info);
        })
        .catch(err => console.log(err));
});

$(document).ready(() => {
    paginate('#pre', pagination_info)
    paginate('#pos', pagination_info)
})