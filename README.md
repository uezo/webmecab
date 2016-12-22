# webmecab
MeCab over HTTP WebService Sample Project

## Usage
* Install [NMeCab](https://www.nuget.org/packages/NMeCab/) on NuGet
```
PM> Install-Package NMeCab
```
* Set the path to ipadic directory in Web.config
```
<setting name="DicDir" serializeAs="String">
  <value>/path/to/dic/ipadic</value>
</setting>
```
* Deploy to Azure or your own ASP.NET server
* Use console.cshtml or open URL like this for testing.
```
http://your_mecab_service_url/parse?text=これはテストです
```
