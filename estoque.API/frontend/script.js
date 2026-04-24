const api = "https://localhost:7272/api/produto";

async function listar() {
    const response = await fetch(api);
    const produtos = await response.json();

    const lista = document.getElementById("lista");
    lista.innerHTML = "";

    produtos.forEach(p => {
        const div = document.createElement("div");
        div.className = "card";

        div.innerHTML = `
        <strong>${p.nome}</strong><br>
        Quantidade: ${p.quantidade}<br>
        Preço: R$ ${p.preco}<br><br>

        <input type="number" placeholder="Qtd baixa" id="baixa-${p.nome}">
        <button onclick="darBaixa('${p.nome}')">Dar Baixa</button>
    `;

        lista.appendChild(div);
    });
}

async function cadastrar() {
    const nome = document.getElementById("nome").value;
    const quantidade = parseInt(document.getElementById("quantidade").value);
    const preco = parseFloat(document.getElementById("preco").value);

    const response = await fetch(api, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ nome, quantidade, preco })
    });

    if (response.ok) {
        alert("Produto cadastrado com sucesso!");
        listar();
    } else {
        alert("Erro ao cadastrar produto.");
    }
}

async function darBaixa(nome) {
    const quantidade = document.getElementById(`baixa-${nome}`).value;

    const response = await fetch(`${api}/baixa?nome=${encodeURIComponent(nome)}&quantidade=${quantidade}`, {
        method: "PUT"
    });

    if (response.ok) {
        alert("Baixa realizada com sucesso!");
    } else {
        alert("Erro ao dar baixa.");
    }

    listar();
}

listar();