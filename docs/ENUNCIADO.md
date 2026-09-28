# Trabalho Prático Individual — RRP de Design e Programação Orientada a Objetos

## 1. Contexto

Uma instituição de ensino precisa controlar a reserva de recursos acadêmicos, como salas, laboratórios, projetores e notebooks. Usuários pertencem a categorias distintas e podem estar sujeitos a políticas diferentes de duração e uso. O sistema precisa preservar a identidade dos objetos, impedir estados inválidos, controlar o ciclo de vida das reservas e evitar que o mesmo recurso seja reservado em períodos conflitantes.

Você recebeu uma implementação parcial. Ela não deve ser descartada nem substituída por um projeto inteiramente novo. Sua tarefa é compreender a solução existente, corrigir seus defeitos e evoluí-la até que todos os requisitos R01–R25 sejam atendidos.

## 2. Conceitos avaliados

O trabalho foi estruturado para mobilizar os conteúdos dos 17 capítulos da apostila: objetos e classes; estado e comportamento; construtores e propriedades; encapsulamento e invariantes; responsabilidades, coesão e acoplamento; colaboração; associação e composição; modelagem de classes; abstração, interfaces e herança; polimorfismo; especificação verificável; análise de alterações; controle de exceções; completude e rastreabilidade; depuração; escolha de técnicas; integração, testes, refatoração e auditoria.

## 3. Regras do domínio

- Usuários e recursos possuem identidade própria.
- Uma reserva relaciona exatamente um usuário, um recurso e um período.
- O período deve possuir início estritamente anterior ao fim.
- Uma reserva nasce no estado `Solicitada`.
- Transições válidas: `Solicitada -> Confirmada`, `Solicitada -> Cancelada`, `Confirmada -> Cancelada`, `Confirmada -> Concluida`.
- Nenhuma outra transição é válida.
- Reservas `Solicitada` e `Confirmada` bloqueiam a agenda.
- Reservas `Cancelada` e `Concluida` não bloqueiam a agenda.
- O mesmo recurso não pode possuir duas reservas bloqueadoras em períodos sobrepostos.
- Dois períodos que apenas se encostam no instante final/inicial não conflitam. Exemplo: 10:00–12:00 e 12:00–13:00 são permitidos.
- Recurso inativo não pode receber nova reserva.
- Aluno pode reservar por no máximo 2 horas.
- Professor pode reservar por no máximo 4 horas.
- A evolução obrigatória acrescentará a política de visitante.

## 4. Forma de trabalho

A implementação pode ser alterada apenas quando necessário para atender aos requisitos. Evite criar camadas, padrões ou bibliotecas que não contribuam diretamente para o problema. Não altere os IDs dos requisitos nem remova os testes públicos. Novos testes podem ser acrescentados.

A solução final deve permanecer executável como aplicação de console e testável por `dotnet test`.

## 5. Critério de correção

A nota não depende de tamanho de código, estética da documentação ou quantidade de commits. Cada ponto está associado a uma condição verificável em `REQUISITOS.md`. Haverá testes adicionais não fornecidos no pacote do aluno.
