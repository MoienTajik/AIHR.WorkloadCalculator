# AIHR - Workload Calculator (Coding Assignment)

## How to Run
First, navigate to the root of the project.

1. Easy way:
```bash
./run.sh
```

2. **Easier recommened way**:
```bash
docker compose up -d
```

<hr/>

## Concerns
### Technical Concerns
- Back-End
  - **Architecture**: As a POC, I kept things simple for now. We have no layers or strict restrictions implemented, and we use only a single Server project and a separate Domain project to re-use for Front-End and Back-End.
  - **Design**: Some of the implementation-related things (DB communication, mapping, logics, error-handling) are directly written in Controllers without using Services/Repositories. Using this method for a POC is ok, but it doesn't work in the long run for a real-world project.  
  - **Database**: Currently, we are using SQLite + EF-Core as our database. SQLite is good for POCs and development/testing, but not for production use. So on production env, database should be changed to another EF-Core battle-tested provider like SQL-Server.
  - **Authentication/Authorization**: There is no authentication/authorization and I have just placed a dropdown to choose Student, but obviously, that won't work in production.
- Front-End
  - **Framework**: To keep things simple, I used ASP.NET Core MVC for the Front-End part. It wouldn't be a good idea to use this stack in production since there aren't enough Razor-aware frontend developers on the market, and it isn't lightweight either! Therefore, a JavaScript framework/library such as Angular, React, or Vue is more suitable for a production environment. Alternatively, Blazor Server or Blazor WASM can be considered.

### Business Concerns
- Currently, learning hours are divided equally in weeks to calculate weekly learning hours. It can be more precise if we separate the learning time for each week.
- With the current design, I added a **MaxHoursToLearnPerDay** parameter, because it's not possible for a human to learn 24 hours a day! So, I let them decide how much time they want to spend learning each day.
- Other features can be offered to the student, such as letting them choose the day of the week they will be available or unavailable and calulcate the final result based on those inputs.
