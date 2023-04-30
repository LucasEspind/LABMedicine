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
- [x] Atualização dos dados de Pacientes
- [x] Atualização do Status de Atendimento 
- [x] Listagem de Pacientes 
- [x] Listagem de Paciente pelo identificador
- [x] Exclusão de Paciente

- [x] Cadastro de Enfermeiros
- [x] Atualização dos dados de Enfermeiros
- [x] Listagem de Enfermeiros
- [x] Listagem de Enfermeiro pelo identificador
- [x] Exclusão de Enfermeiro

- [x] Cadastro de Médico
- [x] Atualização dos dados de Médico
- [x] Atualização do estado no sistema
- [x] Listagem dos Médicos
- [x] Listagem de Médico pelo identificador
- [x] Exclusão de Médico

- [x] Realização de Consulta


### Pré-requisitos

Antes de começar você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[.Net](https://dotnet.microsoft.com/en-us/download) e C#. C# pode ser instalado como extensão no [VisualStudio](https://visualstudio.microsoft.com/pt-br/) ou semelhante, junto dos seus NuGets Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.SqlServer e Microsoft.EntityFrameworkCore.Tools.


### Objetivo

Esse projeto tem como objetivo a automatização e organização do sistema de um hospital, na construção do mesmo foi seguido um documento de exigências disponibilizado pelo cliente.


### Tecnologias

Na construção do código foram utilizadas as ferramentas a seguir:
- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.Net](https://dotnet.microsoft.com/en-us/download)
- [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)


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

Após a inicialização da API, uma página do swagger será iniciada no seu navegador, ou acesse o link informado pelo compilador.

Utilizando o swagger ou qualquer outra interface visual, como o [Postman](https://www.postman.com/downloads/), você poderá acessar as funcionalidades presentes na categoria [Features](#Features). 
Para o cadastro de todos serão necessários: Identificador (incrementado automaticamente pelo sistema), Nome Completo, Gênero (Masculino, Feminino, Prefiro não Informar), Data de Nascimento, CPF (apenas números) e Telefone.


### Cadastro de Paciente 👩

Para o cadastro do paciente, serão informados outros atributos, tais como: lista de alergias, lista de cuidados específicos e convênio (nome do convênio que o paciente possui). No entanto, apenas o atributo contato de emergência é obrigatório.

Exemplo: https://localhost:7050/api/pacientes


### Atualização dos dados de Pacientes 

Para atualizar os dados do paciente, serão solicitados novamente seus dados para que a atualização possa ser realizada. O sistema utiliza uma DTO (Data Transfer Object) para validar as informações e garantir que não ocorram erros durante o processo de atualização. Após a validação, os dados são atualizados no sistema.

Exemplo: https://localhost:7050/api/pacientes/{identificador}


### Atualização do Status de Atendimento 

Para atualizar o status do atendimento, é necessário informar o identificador do paciente e o status desejado. O identificador do paciente deve ser fornecido por meio da rota e o status por meio de uma query.

Exemplo: https://localhost:7050/api/pacientes/{identificador}/status


### Listagem de Pacientes 

Para obter a lista de pacientes, o solicitante só precisa acessar o endpoint e executá-lo. Existe também a opção de filtrar os pacientes por seu status, informando o status desejado por meio da rota. 

Exemplo: https://localhost:7050/api/pacientes


Status válidos: AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, ATENDIDO e NAO_ATENDIDO.


Exemplo2: https://localhost:7050/api/pacientes?status=ATENDIDO


### Listagem de Paciente pelo identificador

Este endpoint retorna apenas os dados do paciente que possui o identificador informado na rota.

Exemplo: https://localhost:7050/api/pacientes/{identificador}


### Exclusão de Paciente

Para excluir um paciente, o solicitante deve fornecer o identificador do paciente desejado. O sistema então, procurará o paciente correspondente em seu banco de dados e o excluirá.

Exemplo: https://localhost:7050/api/pacientes/{identificador}


### Cadastro de Enfermeiro 👩‍⚕️

Para o cadastro do Enfermeiro todos os atributos serão obrigatórios: Instituição de Ensino da Formação e o seu Cadastro do COFEN/UF(Conselho Federal de Enfermagem / Unidade Federativa).


### Atualização dos dados de Enfermeiros

Para realizar a atualização, os dados do enfermeiro serão solicitados novamente. Isso é feito por meio de uma DTO que valida as informações antes de atualizá-las no sistema, garantindo que não ocorram erros durante o processo.

Exemplo: https://localhost:7050/api/enfermeiros/{identificador}


### Listagem de Enfermeiros

Para obter a lista de enfermeiro, o solicitante só precisa acessar o endpoint e executá-lo.

Exemplo: https://localhost:7050/api/enfermeiros


### Listagem de Enfermeiro pelo identificador

Este endpoint retorna apenas os dados do enfermeiro que possui o identificador informado na rota.

Exemplo: https://localhost:7050/api/enfermeiros/{identificador}


### Exclusão de Enfermeiro

Para excluir um enfermeiro, o solicitante deve fornecer o identificador do enfermeiro desejado. O sistema então, procurará o enfermeiro correspondente em seu banco de dados e o excluirá.

Exemplo: https://localhost:7050/api/enfermeiros/{identificador}


### Cadastro de Médico 👨‍⚕️

Para o cadastro do Médico todos os atributos serão obrigatórios: Instituição de Ensino da Formação, Cadastro do COFEN/UF (SC-658781) e a Especialização Clínica.

Especialização Clínicas que o sistema abrange: Clinico_Geral, Anestesista, Dermatologia, Ginecologia, Neurologia , Pediatria, Psiquiatria, Ortopedia.


### Atualização dos dados de Médico

Para realizar a atualização, os dados do Médico serão solicitados novamente. Isso é feito por meio de uma DTO que valida as informações antes de atualizá-las no sistema, garantindo que não ocorram erros durante o processo.


Exemplo: https://localhost:7050/api/medicos/{identificador}


### Atualização do estado no sistema

Para realizar a atualização do estado do médico no sistema é necessário informar o identificador pela rota e o status desejado pela query.


Exemplo: https://localhost:7050/api/medicos/{identificador}/status


### Listagem dos Médicos

Para obter a lista de Médicos, o solicitante só precisa acessar o endpoint e executá-lo.


Exemplo: https://localhost:7050/api/medicos


### Listagem de Médico pelo identificador

Este endpoint retorna apenas os dados do Médico que possui o identificador informado na rota.


Exemplo: https://localhost:7050/api/medicos/{identificador}


### Exclusão de Médico

Para excluir um Médico, o solicitante deve fornecer o identificador do Médico desejado. O sistema então, procurará o Médico correspondente em seu banco de dados e o excluirá.


Exemplo: https://localhost:7050/api/medicos/{identificador}


### Realização de Consulta 🩺

Para a realização da consulta apenas deve ser informado os Identificadores do paciente e do médico, após isso o status do paciente mudará para ATENDIDO e o número de atendimentos de ambos aumentara em 1. No banco de dados ficarão salvos o código da consulta, o identificador do médico e do paciente e a especialização médica.


### Listagem de Consultas


A listagem de Consultas é um endpoint que retorna todas as consultas realizadas por todos os médicos.

Exemplo: https://localhost:7050/api/Atendimentos


### Listagem de Consultas por Paciente


A listagem de Consultas por Paciente é um endpoint que solicita pela rota o identificador do paciente e retorna todas as suas consultas realizadas.

Exemplo: https://localhost:7050/api/Atendimentos/{idMedico}


### Listagem de Consultas por Médico


A listagem de Consultas por Médico é um endpoint que solicita pela rota o identificador do Médico e retorna todas as suas consultas realizadas.

Exemplo: https://localhost:7050/api/Atendimentos/{idMedico}


### Autor

Lucas de Espindola
