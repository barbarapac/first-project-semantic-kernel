# First Project Semantic Kernel

Uma aplicação console simples que demonstra o uso do Microsoft Semantic Kernel com Ollama para criar um chatbot interativo com suporte a plugins.

## Propósito

Esta aplicação permite conversar com um modelo de IA local (Llama 3.1) através de uma interface de linha de comando, com capacidade de executar funções personalizadas através de plugins.

## Funcionalidades

- Chat interativo via console
- Integração com Ollama (modelo llama3.1:latest)
- Suporte a plugins personalizados (ProductPlugins)
- Histórico de conversação mantido durante a sessão
- Execução automática de funções quando necessário

## Pré-requisitos

- .NET 8.0 ou superior
- Ollama instalado e rodando na porta 11434
- Modelo llama3.1:latest baixado no Ollama

## Como usar

1. Execute a aplicação
2. Digite suas mensagens no prompt "User > "
3. O assistente responderá usando o modelo de IA
4. Digite Enter sem texto para sair

## Tecnologias

- Microsoft Semantic Kernel
- Ollama Connector
- .NET Console Application