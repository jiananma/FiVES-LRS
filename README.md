# FiVES

Flexible Virtual Environment Server

The goal of this project is to build a flexible virtual world server that can be used to build various synchronized applications with different requirements. Its architecture is highly modular, providing a lightweight base application with a very flexible plugin mechanism.

__*FiVES is part of the FIWARE project, funded by the European Union. There, FiVES is provided as alternative implementation if the 'Synchronization' Generic Enabler. For more information, please refer to http://www.fiware.org*__

# Project Structure

## Directories

The following directories exist in the repository:

<table>
  <tr>
    <th>Directory</th>
    <th>Purpose</th>
  </tr>
  <tr>
    <td>Core</td>
    <td>contains core libraries for the server</td>
  </tr>
  <tr>
    <td>Docs</td>
    <td>contains files for generating documentation</td>
  </tr>
    <tr>
    <td>Misc</td>
    <td>Different tools for testing</td>
  </tr>
  <tr>
    <td>FIVES</td>
    <td>contains the server application</td>
  </tr>
  <tr>
    <td>Plugins</td>
    <td>contains server plugins</td>
  </tr>
  <tr>
    <td>ServiceBus</td>
    <td>Contains the Plugin-Service-Orchestration bus</td>
  </tr>
  <tr>
    <td>ThirdParty</td>
    <td>contains 3rd-party libraries not available in nuGet</td>
  </tr>
  <tr>
    <td>WebClient</td>
    <td>contains Web-client for testing the server</td>
  </tr>
</table>

The following directories may be generated dynamically:

<table>
  <tr>
    <th>Directory</th>
    <th>Purpose</th>
  </tr>
  <tr>
    <td>Binaries</td>
    <td>
      contains compiled plugins and protocols with all required third-party
      dependencies and debug files. New versions of plugins and protocols are
      automatically copied here and FiVES application automatically loads
      plugins and protocols from this directory. This makes edit-compile-test
      cycle easier.
    </td>
  </tr>
  <tr>
    <td>packages</td>
    <td>created by nuGet to contain 3rd party libraries</td>
  </tr>
  <tr>
    <td>test-results</td>
    <td>created by MonoDevelop to contain unit test results</td>
  </tr>
</table>

## Overall Architecture

The FiVES project consists of three main parts:

* The core server application that maintains the world data in an entity-component-attribute like fashion and loads and schedules the set of plugins. (Contained in this Repo, __Core__ folder).
* A set of plugins that implement specific logic. Whenever you want to enrich your application with new features, these features will be provided by one or more plugins. The Plugins folder in this project contains a base set of plugins that may be helpful to get started with creating interactive 3D virtual world applications. An additional set of more specialised, experimental plugins is published separately at __https://github.com/fives-team/fives-experimental-plugins.__
* The communication middleware _SINFONI_. In short, SINFONI aims at simplyfing network communication by abstracting from data serialization, marshalling and transport, and hides all this behind a simple, RPC like interface. SINFONI is modular and provides a set of serialization and transport mechanisms. SINFONI is provided in FiVES as precompiled binaries in the ThirdParty/SINFONI folder. The complete source code is provided under LGPL v3 license at https://github.com/tospie/SINFONI
 
## Third-party libraries

We use nuGet to manage third-party libraries. If you want to build FIVES, please
install nuGet into your IDE and restore all packages. Some libraries that are
not available in nuGet are located in ThirdParty directory.

# Getting Started

## Building and running FiVES

All third party libraries that are needed to build FiVES are either supplied within the project, or managed by the NuGet package manager: http://www.nuget.org . Simply add NuGet to your IDE, select to restore packages on build, and build the entire solution.

FiVES can be built and run on both Windows and Linux system.

To run FiVES, just double click _FIVES.exe_ (Windows), or use mono to run FiVES (Linux) by typing `mono FIVES.exe` .
FiVES requires Administrator rights under Windows to be allowed to open HTTP listener ports.

# License

FiVES is provided subject to terms of the GNU LGPL v3 license. Please refer to the LICENSE file for more information. All third-party libraries come with their own licenses. Details about third party licenses are given in the Readme file in the third party folder, and on the project webpages of the different projects.
