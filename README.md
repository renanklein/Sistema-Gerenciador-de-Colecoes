# Sistema-Gerenciador-de-Colecoes

### Descrição

É um sistema de gerenciamento onde o usuário poderá controlar suas coleções, realizar pesquisas personalizadas para localizar determinado objetos da coleção. Também será possível emprestar itens da coleção para outras pessoas, informando os dados necessários da pessoa requisitante.

### Tecnologias

O sistema terá duas partes: 
- Uma api para suprir as requisições do usuário, que será desenvolvida em C# utilizando o framework .NET core 2.2.
- Interface com o usuário, que será construida utilizando HTML, CSS e JavaScript.

### Como executar o projeto
(OBS: O Projeto utiliza o banco de dados PostgreSQL para persistencia dos dados)
Para executar a api :
- Ao baixar o repositório, importe o projeto  utilizando o Visual Studio. 
- Para isso na tela inicial do Visual Studio, no menu introdução, selecione a opção "Abrir um projeto ou solução" e abra o arquivo API_Colecoes.csproj.
- Verifique se seus dados de conexao com o banco condizem com os dados de acesso na classe "ItemContext"
- Para carregar as migrations para popular o banco utilize o comando no terminal do Visual Studio:
<code> dotnet ef migrations add ModeloTabelas </code>
- Ao carregar o Visual Studio, na parte superior logo abaixo das opções "Análise" e "Ferramentas" selecione a opção "API_Colecoes" e execute.

Para a Interface :
- Caso não tenha o npm instalado : <a href="https://www.npmjs.com/get-npm">Clique aqui</a>
- Para instalar o http-server, abra o terminal de sua preferência, acesse a pasta Interface pelo mesmo e execute:
<code> npm i http-server -g </code>
- Para rodar o http-server :
<code> http-server -p --numero_da_porta-- </code>
- Basta acessar um dos dois link que serão exibidos ao rodar o http-server pelo comando ctrl + click 
