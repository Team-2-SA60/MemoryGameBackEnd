# Memory Game Team 2 SA4108 🧠 (Backend)
[![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)](https://hub.docker.com/repository/docker/imksc/yourapp/general)
[![DigitalOcean](https://img.shields.io/badge/DigitalOcean-%230167ff.svg?style=for-the-badge&logo=digitalOcean&logoColor=white)](https://www.digitalocean.com/)

#### A card matching game built in Kotlin (Android Studio) and .NET (Backend). This repository is the ASP.NET backend. Android Native Frontend can be accessed [here](https://github.com/Team-2-SA60/MemoryGameAndroid.git).
#### This project utilises GitHub Actions for Continuous Deployment to DigitalOcean Cloud
---

## Getting Started

### Prerequisites

- [.NET 8.0 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL 8.0.36 or later](https://dev.mysql.com/downloads/)

### Installation
1. Clone Repo
   ```
   git clone https://github.com/Team-2-SA60/MemoryGameBackEnd.git

2. Open terminal and change directory 2 times to access project files
   ```
   cd MemoryGameBackEnd
   ```
   ```
   cd MemoryGameBackEnd
   ```
3. Restore dependencies
   ```
   dotnet restore
   ```
4. Update SQL Connection String for the following file to your local MySQL server credentials
   ```
   appsettings.json
   ```
   ```json
   "MySQL": "server=localhost;database=MemoryGame;user=root;password=sql"
   ```
- Replace
   > user={Your_MySQL_Username} \
   > password={Your_MySQL_password}
5. Run the application
   ```
   dotnet run
   ```
6. Test API requests
   ```bash
   curl -X 'GET' \
     'http://localhost:5062/api/Game/top10?daysAgo=0' \
     -H 'accept: text/plain'
   ```
- Expected json output
   ```json
   [
      {
         "gameId": 0,
         "userId": 0,
         "username": string,
         "completionTime": 0,
         "avatarImage": string
      }
   ]
   ```
---
## Team 2️⃣

- [@Adrian](https://github.com/adriantlh)
- [@Bo Fei](https://github.com/Bofei2058)
- [@Cai Yun](https://github.com/vegecloud)
- [@Kin Seng](https://github.com/im-ksc)
- [@Gong Yuan](https://github.com/gongyuannn)
- [@Run Xin](https://github.com/ZRX471)
