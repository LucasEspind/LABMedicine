<h1 align="center"> LABMedicine </h1>

<p align="center">API para gestão e automatização de um hospital</p>

<p align="center">
 <a href="#objetivo">Objetivo</a> •
 <a href="#tecnologias">Tecnologias</a> • 
 <a href="#autor">Autor</a>
</p>


<h4 align="center"> 
	👨‍⚕️ Projeto Concluido! 👩‍⚕️
</h4>

### Features

- [x] Cadastro de Paciente
- [x] Cadastro de Enfermeiros
- [x] Cadastro de Médicos
- [x] Realização de Consulta

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[.Net](https://dotnet.microsoft.com/en-us/download), C# que pode ser instalado como extenção no [VisualStudio](https://visualstudio.microsoft.com/pt-br/) ou semelhante, junto dos seus NuGets Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.SqlServer e Microsoft.EntityFrameworkCore.Tools.

### Tecnologias

Na construção do código foram utlizadas as ferramentas a seguir:
- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.Net](https://dotnet.microsoft.com/en-us/download)


### Rodando a API

```bash
# Clone este repositório
$ git clone <https://github.com/LucasEspind/Modulo1-ProjetoAvaliativo.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd Modulo1-ProjetoAvaliativo

# Execute a aplicação
$ dotnet run

# A API inciará em uma porta aleatória informada pelo compilador - acesse <http://localhost:(porta informada pelo compilador)> 
```

### Utilizando a API

Após a inicalização da API, uma página do swagger será iniciada no seu navegador, ou acesse o link informado pelo compilador

Utilizando o swagger ou qualquer outra interface visual, como o [Postman](https://www.postman.com/downloads/), você poderá acessar as funcionalidades a seguir:

<a href="#Cadastro de Paciente">- Cadastro de Paciente</a>
<a href="#Cadastro de Enfermeiro">- Cadastro de Enfermeiro </a>
<a href="#Cadastro de Médico">- Cadastro de Médico </a>
<a href="#Realização de Consulta">- Realização de Consulta</a>

Para o cadastro de todos serão necessários: Identificador, Nome Completo, Gênero, Data de Nascimento, CPF e Telefone.

### Cadastro de Paciente

Para o cadastro do Paciente serão informadas alguns outros atributos: Lista de Alergias, Lista de Cuidados Específicos, Convênio sendo que o único obrigatório é o Contato de Emergência.

### Cadastro de Enfermeiro

Para o cadastro do Enfermeiro todos os atributos serão obrigatórios: Instituição de Ensino da Formação e o seu Cadastro do COFEN/UF.

### Cadastro de Médico

Para o cadastro do Médicop todos os atributos serão obrigatórios: Instituição de Ensino da Formação, Cadastro do COFEN/UF e a Especialização Clínica.

### Realização de Consulta

Para a realização da consulta apenas deve ser informado os Identificadores do paciente e do médico, após isso o status do paciente mudará para ATENDIDO e o número de atendimentos de ambos aumentara em 1.

### Autor
--- Lucas de Espindola