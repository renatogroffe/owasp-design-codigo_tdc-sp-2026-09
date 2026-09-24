# OWASP Top 10:2025 - A03: Software Supply Chain Failures

Um exemplo de problema em Node.js, detectado com a ferramenta Snyk:

```text
user@workstation goof % snyk test
Testing /Users/jsmith/git/goof...
Tested 554 dependencies for known issues, found 137 issues, 469 vulnerable paths.
Issues to fix by upgrading:
Upgrade adm-zip@0.4.7 to adm-zip@0.5.2 to fix
✗ Directory Traversal [High Severity][https://security.snyk.io/vuln/SNYK-JS-ADMZIP-1065796] in adm-zip@0.4.7
introduced by adm-zip@0.4.7

```

---

Atualizando dependências em .NET com dotnet-outdated

```bash
dotnet outdated -u
```

Saiba mais em: **https://github.com/dotnet-outdated/dotnet-outdated**

---

Monitoramento contínuo em um cluster Kubernetes: **https://github.com/renatogroffe/trivy_operator-aks-managed_prometheus**