# Dashyboard
The goal of this project is to create a versatile platform for creating dashboard applications easily from UWP (Windows 10 apps) platform. The inspiration are the multiple "magic mirror" projects done on some Raspberry Pi projects.

## Technologies
Not all required researches are done for the feasibility of the components, but here's the major technologies that will be used for the project:
- Microsoft Packages (appx) and the new Application Extensibility Framework
- Brokered Component to host controls from another appx (the Microsoft Ads SDK is already doing that)
- Packages server for IoT applications with possibility to deploy configuration too and "push" packages to devices

## Features
The first version of the project will have the following features:
- Easy dashboard for any UWP device (developped for IoT, but not limited to those devices)
- Deployment & updates of configuration (all platforfms) + packages on IoT
- Ability to build applications by using hosting dashyboard in app
- SDK/API for easy creation of components

## Components
The roadmap is to create the following components
- A hostable shell
- A default application to host the shell
- A layouter
- Default dashboard components
- Extensible dashbouard components + SDK to create more

## Vocabulary
### Dashyboard
This is the platform name
### Part
A part is a visual display on dashyboard.
### Parts Provider
A part provider is a package who can supply parts to the shell.
### Layouter
A layouter is a logic for layouting parts on the available surface.  See this as mostly an intelligent "custom panel" in XAML.
### Shell
Component responsible for managing parts provider, decide which parts to present, choose the right layouter and produce a result.
### Application
The Dashyboard application is a ready-to-use application hosting the Dashyboard shell.
