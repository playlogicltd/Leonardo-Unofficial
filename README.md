# Leonardo-Unofficial SDK for accessing the LeonardoAI API
A simple C# .NET wrapper library to use with Leonardo's API.  This is an unofficial wrapper library around the Leonardo API.  I am not affiliated with Leonardo and this library is not endorsed or supported by them.

# Quick Example
```C#
var api = new Leonardo.LeonardoAPI("YOUR_API_KEY");
var generationId = await api.Generate.Image("Brown cat with a bowtie");
var images = await api.Generate.GetGeneratedImages(generationId);
// should get 4 images with that prompt.  It's possible that Leonardo has not started yet
// in which case the response will have a Status of "PENDING" or "FAILED" within the images object
```

# TODO

Cleanup code base, add more examples in readme for all examples.
