$(document).ready(() => {
    if(localStorage.getItem("msg")){
        $("main").prepend(localStorage.getItem("msg"));
        localStorage.clear();
    }
    axios.get("http://localhost:5000/api/item")
        .then(resp => {
            console.log(resp.data);
            let items = resp.data;
                items.forEach(item => {
                    let html = `<td>${item.tipo}</td>
                                <td>${item.nome}</td>
                                <td>${item.categoria}</td>
                                <td>${item.autor}</td>
                                <td>${item.status}</td>
                                <td><a href="html/emprestar?id=${item.itemId}">Emprestar</a></td>`;
                    $('tbody').append("<tr>").append(html);
            });
        })
        .catch(err => console.log(err));
});