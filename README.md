  

<img  alt="hackathon"  src="https://i.imgur.com/yvhrSvH.png"  width="500px"  align="center"  />

  

# Desafio: Ferramentas de Geração de Código

O desafio desse Hackathon é criarmos um gerador de códigos para que as tarefas repetitivas dos times sejam realizadas com mais inteligência e performance.

# Tabela de conteúdos

<!--ts-->

*  [Tabela de Conteúdos](#tabela-de-conteúdos)

*  [Solução proposta](#solução-proposta)

*  [Status](#status)

*  [Requisitos](#requisitos)

*  [Instalação](#instalação)

*  [Tecnologias](#tecnologias)

*  [GitFlow](#gitflow)

*  [Time](#time)

<!--te-->


## Solução proposta

Foi criado uma library que tem por função a criação do CRUD automatizado, apenas dependendo do Model previamente criado pelo usuário.

A library deve ser instalada globalmente no computador para a utilização via CLI(verificar no tópico "Instalação")

Para essa solução, é pressuposto que será usador Dapper como ORM e SQL-SERVER como Banco de Dados.

Comandos:
```bash
# Como usar

$ monster [argumento]

# Comandos disponíveis:

# Exibe informações do Monster

$ -a|--about 

# Exibe a usabilidade dos comandos

$ -h|--help 

# Exibe a versão em uso

$ -v|--version

# Cria o CRUD para o Model informado

$ -c|--className <classname.cs> 

# Exemplos(o nome  do  Model deve conter a extensão .cs)

$ monster --className Professor.cs

$ monster -c Processor.cs

$ monster --help
```


## Status

<h4> 🚧 API .Net 🚀 em construção... 🚧 </h4>

#### Roadmap
- [x] Criação do CRUD automatizado
- [ ] Construção de HTTP client automático
- [ ] Parâmetro de path e nome da pasta
- [ ] CRUD com outras tecnologias (entity framework)
- [ ] Parâmetro de escolha de Banco de Dados


## Requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:

[Visual Studio 2019](https://visualstudio.microsoft.com/vs/)

[SDK .Net Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

[Git](https://git-scm.com/)

Você também precisa de uma solução já criada com as Classes das Models previamente feitas. 
Essas Classes serão usadas como parâmetro para a Geração do CRUD automática.

  

## Instalação

```bash

# Baixe o pacote no link abaixo

https://drive.google.com/file/d/1rvAit6TbRvzGzcmGJpPXy8nqyCFXIkCj/view?usp=sharing

 
# Entre no diretório do pacote baixado e execute o comando

$ dotnet tool install --global --add-source ./ cadmus.monster

  
# Execute o comando para verificar a instalação

$ monster --version

  
# Entre no diretório raiz do projeto desejado e execute o comando para gerar o CRUD

$ monster --className <NomeClasse.cs>


# Para desinstalar o pacote basta executar

$ dotnet tool uninstall -g cadmus.monster
```

  

## Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

-  [Donet Core 5.0](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-5.0)

  

## Git:

```bash

# Baixar o código fonte da solução

$ git clone https://github.com/Leonardohrp/hackatonCadmus.git
```

  

## Time

<p  align="center"><img  src="https://img.shields.io/static/v1?label=Cadmus&message=Time Monster&color=42b6f5&style=for-the-badge&logo"/></p>

<table  align="center">

<tr  border="hidden">

<td  align="center"  border="hidden"><a  href="https://github.com/joaorabelo"><img  src="https://i.imgur.com/NsccSc0.jpg"  width="100px;"  height="100px"  alt=""/><br  /><sub><b>João Rabelo</b></sub></a></td>

<td  align="center"><a  href="https://github.com/leonardohrp"><img  src="https://i.imgur.com/LxJ1dxG.jpg"  width="100px;"  height="100px"  alt=""/><br  /><sub><b>Leonardo Pinheiro</b></sub></a></td>

<td  align="center"><a  href="https://github.com/ptortello"><img  src="https://i.imgur.com/RuXDqgZ.jpg"  width="100px;"  alt=""/><br  /><sub><b>Pedro Tortello</b></sub></a></td>

<td  align="center"><a  href="https://www.linkedin.com/in/rafael-quevedo-fernandes-390b072b/"><img  src="https://i.imgur.com/fvLrrUJ.jpg"  width="100px;"  alt=""/><br  /><sub><b>Rafael Fernandes</b></sub></a></td>

<td  align="center"><a  href="https://www.linkedin.com/in/rafael-tadioto-2583a42a/"><img  src="https://i.imgur.com/yx1gHgy.jpg"  width="100px;"  alt=""/><br  /><sub><b>Rafael Tadioto</b></sub></a></td>

</tr>

</table>