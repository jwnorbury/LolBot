# MatchUpBot
A discord bot to display matchup information via text chat.

TODO
Features
- As scope of services is expanding, rename project and repository to more generic name 'LoLBot' or similar.
- Add counters
  - Possibly via scraping op.gg
  - !vs missfortune (role)

Technical
- Create ILolService interface which each service (Build, MatchUp) implements.
- Create ILogging interface
  - Rename LoggingService to LoggingProvider
  - Create LoggingService which initially calls LoggingProvider
- Create IConfig interface
  - Create ConfigService which initially calls ConfigProvider
- Implement DI for interfaces
