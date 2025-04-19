# 🧭 Tratamento global de erros em Angular 19 + .NET

Este projeto demonstra uma implementação **completa, robusta e elegante** de tratamento de erros para aplicações Angular 19, com backend em .NET. Ele cobre desde erros HTTP e falhas de rede até exceções não tratadas na aplicação. Também inclui suporte a **funcionamento offline**, armazenamento local de logs e sincronização automática com o backend assim que a conexão for restabelecida.

---

## 📐 Arquitetura

A arquitetura é baseada em 4 pilares principais:

1. **Interceptor HTTP** – captura todos os erros de requisições feitas com `HttpClient`, tratando por tipo de status (`401`, `403`, `500`, etc.);
2. **ErrorHandler global** – captura erros JavaScript que escapam do Angular, como exceções de lógica, erros assíncronos ou em promessas;
3. **Serviços de suporte** – logging, notificação e armazenamento offline de erros;
4. **Camada de apresentação (UI)** – mensagens amigáveis ao usuário via `Snackbar`.

---

## 🧱 Estrutura de pastas (frontend Angular)

```
src/
├── app/
│   ├── core/
│   │   ├── error/
│   │   │   ├── interceptors/
│   │   │   │   └── http-error.interceptor.ts
│   │   │   ├── handlers/
│   │   │   │   └── global-error.handler.ts
│   │   │   ├── services/
│   │   │   │   ├── log.service.ts
│   │   │   │   ├── notification.service.ts
│   │   │   │   └── offline.service.ts
│   ├── shared/
│   │   └── snackbar/
│   │   │   ├── components/
│   │   │   │   ├── snackbar.component.html
│   │   │   │   ├── snackbar.component.ts
│   │   │   ├── services/
│   │   │   │   ├── snackbar.service.ts
```

---

## ⚙️ Funcionalidades Implementadas

### ✅ Interceptor HTTP

- Captura erros HTTP automaticamente
- Trata `401`, `403`, `404`, `500` e outros
- Redireciona para login, mostra toasts e registra logs

### ✅ ErrorHandler Global

- Captura erros não-HTTP como:
  - exceções em componentes
  - eventos de usuário
  - operações RxJS sem `catchError`

### ✅ Logging com fallback offline

- Armazena erros no `localStorage` se estiver offline
- Tenta sincronizar automaticamente com o backend quando a conexão voltar
- Usa `HttpContext` para ignorar erros silenciosos nos pings

### ✅ OfflineService inteligente

- Só começa a fazer “ping” após detectar um erro de rede (status `0`)
- Para o ping assim que o servidor responder e os erros forem sincronizados

---

## 🌐 Backend ASP.NET (.NET 8)

### 📂 `erros-api`

API simples com os seguintes endpoints:

- `GET /api/v1/health` – Usado pelo frontend para checar se o servidor está online
- `POST /api/v1/errorlog` – Recebe logs individuais
- `POST /api/v1/errorlog/bulk` – Recebe logs armazenados localmente em lote
- `GET /api/v1/test/x` – Simula erros

---

## 🛠️ Tecnologias Utilizadas

| Camada      | Tecnologia                 |
|-------------|----------------------------|
| Frontend    | Angular 19, RxJS 8         |
| UI          | Snackbar independente de lib externa |
| Backend     | ASP.NET Core 8 |
| Armazenamento offline | `localStorage`   |

---

## 🚀 Como rodar

### Frontend

```bash
cd erros
npm install
ng serve
```

### Backend

```bash
cd erros-api
dotnet run
```

---

## 📣 Créditos e Inspiração

Esse projeto foi cuidadosamente estruturado para resolver um problema real: **como lidar com erros de forma elegante, completa e resiliente no Angular**, sem reinventar a roda e sem sobrecarregar a experiência do usuário.

Desenvolvido com ❤️ por [Vanessa Ortega](https://github.com/ortegavan)  
Orientado por muita prática, tentativa e uma pitada de perfeccionismo 🧪✨

---

## 🧭 Para onde ir a partir daqui?

- 🔐 Adicionar autenticação com JWT e logs por usuário
- 📊 Integrar com ferramenta externa de monitoramento (Sentry, LogRocket)
- 💾 Substituir `localStorage` por IndexedDB para logs offline maiores
- 🧪 Cobrir com testes E2E e mocking do backend

---

> Se você quer que sua aplicação Angular seja mais resiliente, acessível e preparada para o mundo real… este projeto é um excelente ponto de partida.