# MntVazaoWebApi

Uma aplicação Web API desenvolvida em ASP.NET Core 3.1 para visualizar por gráfico e tabela os dados aferidos por um sensor de água.

<h4 align="center"> 
  <a href="#Tecnologias-e-ferramentas">Tecnologias e ferramentas</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#sobre-o-projeto">Sobre o projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Demonstração">Demonstração</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  </br>
  <a href="#Como-usar">Como usar</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Licença">Licença</a>
</h4>

<br/>

<p align="center">
  <a href="https://opensource.org/licenses/MIT">
    <img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License MIT">
  </a>
</p>

# Tecnologias e ferramentas

O projeto foi desenvolvido com as seguintes tecnologias e ferramentas:

- [Visual Studio 2019 Community](#Pré-requisitos)
- [Asp.NET Core 3.1](#Pré-requisitos)
- [Chart.Js](#Pré-requisitos)
- [DataTables](#Pré-requisitos)
- [Swagger](#Pré-requisitos)

# Sobre o projeto

Este é um projeto Web API com ASP.NET Core 3.1 para consultar tanto por tabela quanto por gráfio os dados obtidos de um banco de dados, além de disponibilizar uma documentação de como usar a API, criada com Swagger.

Abaixo, está o diagrama do banco de dados utilizado neste projeto:

<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoWebApi/blob/main/Github/BD.png"/>
</p>

# Demonstração

A aplicação é composta de 3 telas.   

1 - Visualização das medições da vazão de água por meio de gráfico. A tela, apresenta-se, de forma gráfica, o consumo diário (litros/dia) e o consumo horário (litros/hora).
    
<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoWebApi/blob/main/Github/Grafico.PNG">
</p>

2 - A tela abixo permite realizar consultas pela identificação do sensor (ID), pela data de início da leitura, data final da leitura, por algum valor específico, em litros (L), das medições inseridas no banco de dados e pelo status de ativação do sensor.

<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoWebApi/blob/main/Github/Dados.PNG">
</p>

3 - API documentada, a mesma consumida pelo projeto Xamarin (https://github.com/renanegobbi/MntVazaoApp). 

<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoWebApi/blob/main/Github/API.PNG"/>
</p>

# Como usar
Após clonar o projeto, atualizar a string de conexão no arquivo appsettings.json para que fique configurado conforme seu banco de dados.

# Licença
Este projeto está sob a licença do MIT. Consulte a [LICENÇA](https://github.com/TesteReteste/lim/blob/master/LICENSE) para obter mais informações.
