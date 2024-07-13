## Requisitos Funcionais

### 1. Cadastro de Usuários Voluntários

**Descrição:**
Será possível cadastrar usuários voluntários para que seja possível entrar em contato com eles.

**Critérios de Aceite:**
- O sistema deve permitir o cadastro de usuários voluntários com as seguintes informações: nome, e-mail, telefone, endereço e áreas de interesse.
- O sistema deve armazenar os dados dos usuários voluntários em um banco de dados SQL.
- Deve ser possível buscar e listar usuários voluntários por região e áreas de interesse.

### 2. Cadastro de Modalidades de Trabalho

**Descrição:**
Será possível cadastrar modalidades de trabalho (doação de roupas, Serviço, etc).

**Critérios de Aceite:**
- O sistema deve permitir o cadastro de diferentes modalidades de trabalho com suas respectivas descrições.
- O sistema deve armazenar as modalidades de trabalho em um banco de dados SQL.

### 3. Cadastro de Endereços para Pontos de Encontros

**Descrição:**
Será possível cadastrar endereços para pontos de encontros (quando usuário colocar CEP, encontrar o local mais próximo precisando de ajuda).

**Critérios de Aceite:**
- O sistema deve permitir o cadastro de endereços para pontos de encontro com suas respectivas descrições.
- O sistema deve armazenar os endereços em um banco de dados NoSQL.
- Deve ser possível buscar e listar pontos de encontro por CEP e região.

## Requisitos Não Funcionais

### 1. Restrições de Doações Monetárias

**Descrição:**
Não será possível realizar doações monetárias (Pix, cartão de crédito, etc).

**Critérios de Aceite:**
- A plataforma não deve oferecer nenhum meio para doações financeiras.
- Qualquer tentativa de realizar doações monetárias deve ser bloqueada pelo sistema.

### 2. Restrições de Doações de Roupas

**Descrição:**
Não será possível realizar doações de roupas através da plataforma.

**Critérios de Aceite:**
- A plataforma não deve oferecer funcionalidades para doações de roupas diretamente.
- Informações sobre doações de roupas devem ser limitadas a cadastro de modalidades e submodalidades.

### 3. Privacidade dos Dados dos Usuários

**Descrição:**
Não haverá contato entre os possíveis doadores através da plataforma; dados serão sigilosos.

**Critérios de Aceite:**
- O sistema deve garantir a privacidade dos dados dos usuários voluntários.
- Informações de contato dos usuários não devem ser visíveis ou acessíveis a outros usuários.
- Apenas moderadores e administradores autorizados devem ter acesso aos dados de contato dos voluntários.

## Análise do Uso de SQL e NoSQL no Projeto

### Pontos Positivos do Uso de SQL

1. **Consistência de Dados:**
   - SQL oferece transações ACID, garantindo a consistência e integridade dos dados, essencial para operações críticas como o cadastro de usuários e moderadores.

2. **Estruturação de Dados:**
   - SQL é ideal para dados estruturados, onde o esquema é bem definido. As tabelas relacionais são apropriadas para armazenar informações de usuários, modalidades de trabalho e submodalidades.

3. **Consultas Complexas:**
   - SQL permite realizar consultas complexas e joins eficientes, facilitando a recuperação de informações detalhadas e inter-relacionadas, como associar voluntários a determinadas modalidades de trabalho.

4. **Maturidade e Suporte:**
   - Bancos de dados SQL, como MySQL, PostgreSQL e SQL Server, são maduros e amplamente suportados, oferecendo diversas ferramentas e documentação para desenvolvimento e manutenção.

### Pontos Positivos do Uso de NoSQL

1. **Flexibilidade de Esquema:**
   - NoSQL oferece flexibilidade de esquema, permitindo a adição de novos campos sem a necessidade de redefinir a estrutura do banco de dados, útil para armazenar endereços e informações geográficas.

2. **Desempenho em Leitura:**
   - NoSQL, especialmente bancos de dados orientados a documentos como MongoDB, são otimizados para leitura rápida, o que é benéfico para consultas geográficas e recuperação de pontos de encontro.

3. **Escalabilidade:**
   - NoSQL oferece escalabilidade horizontal, facilitando o gerenciamento de grandes volumes de dados e alta disponibilidade, essencial para uma API que pode crescer em número de usuários e pontos de encontro.

4. **Adequação a Dados Geoespaciais:**
   - Bancos de dados NoSQL como MongoDB têm suporte nativo para dados geoespaciais, facilitando a implementação de funcionalidades de busca por geolocalização.

## Recomendação

Para este projeto, a recomendação é usar uma abordagem híbrida, combinando SQL e NoSQL para aproveitar os pontos fortes de ambos:

- **SQL:**
  - **Usuários Voluntários:** Cadastro e gerenciamento de dados pessoais e áreas de interesse dos voluntários.
  - **Modalidades de Trabalho:** Estruturação clara e relacionamentos entre modalidades.

- **NoSQL:**
  - **Busca por Geolocalização:** Implementação eficiente de funcionalidades de busca e mapeamento de pontos de encontro próximos ao CEP fornecido.

## Justificativa

- **Consistência e Integridade:** SQL é ideal para dados que requerem consistência e integridade, como informações de usuários e relacionamentos entre modalidades de trabalho.
- **Flexibilidade e Desempenho:** NoSQL é adequado para dados geográficos e consultas que necessitam de flexibilidade e alta performance, como a busca por pontos de encontro.
- **Escalabilidade:** A combinação permite que o sistema escale horizontalmente para grandes volumes de dados geoespaciais e mantenha a integridade de dados estruturados.
