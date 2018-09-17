# MatchUpBot
A discord bot to display matchup information via text chat.

TODO
- As scope of services is expanding, rename project and repository to more generic name 'LoLBot' or similar.
- Create ILogging interface
  - Rename LoggingService to LoggingProvider
  - Create LoggingService which initially calls LoggingProvider
- Create IConfig interface
  - Create ConfigService which initially calls ConfigProvider
- Implement DI for interfaces
