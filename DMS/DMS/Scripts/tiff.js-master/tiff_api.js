var Tiff = (function () {
    function Tiff(params) {
        if (Tiff.Module === null) {
            Tiff.initialize({});
        }
        this._filename = Tiff.createFileSystemObjectFromBuffer(params.buffer);
        this._tiffPtr = Tiff.Module.ccall('TIFFOpen', 'number', ['string', 'string'], [this._filename, 'r']);
        if (this._tiffPtr === 0) {
            throw new Tiff.Exception('The function TIFFOpen returns NULL');
        }
    }
    Tiff.initialize = function (options) {
        if (Tiff.Module !== null) {
            return;
        }
        Tiff.Module = loadModule(options);
    };

    Tiff.prototype.width = function () {
        return this.getField(Tiff.Tag.IMAGEWIDTH);
    };

    Tiff.prototype.height = function () {
        return this.getField(Tiff.Tag.IMAGELENGTH);
    };

    Tiff.prototype.currentDirectory = function () {
        return Tiff.Module.ccall('TIFFCurrentDirectory', 'number', ['number'], [this._tiffPtr]);
    };

    Tiff.prototype.countDirectory = function () {
        var count = 0;
        var current = this.currentDirectory();
        while (true) {
            count += 1;
            var status = Tiff.Module.ccall('TIFFReadDirectory', 'number', ['number'], [this._tiffPtr]);
            if (status === 0) {
                break;
            }
        }
        this.setDirectory(current);
        return count;
    };

    Tiff.prototype.setDirectory = function (index) {
        return Tiff.Module.ccall('TIFFSetDirectory', 'number', ['number', 'number'], [this._tiffPtr, index]);
    };

    Tiff.prototype.getField = function (tag) {
        var value = Tiff.Module.ccall('GetField', 'number', ['number', 'number'], [this._tiffPtr, tag]);
        return value;
    };

    Tiff.prototype.readRGBAImage = function () {
        var width = this.width();
        var height = this.height();
        var raster = Tiff.Module.ccall('_TIFFmalloc', 'number', ['number'], [width * height * 4]);
        var result = Tiff.Module.ccall('TIFFReadRGBAImageOriented', 'number', ['number', 'number', 'number', 'number', 'number', 'number'], [
            this._tiffPtr, width, height, raster, 1, 0
        ]);

        if (result === 0) {
            throw new Tiff.Exception('The function TIFFReadRGBAImageOriented returns NULL');
        }

        // copy the subarray, not create new sub-view
        var data = Tiff.Module.HEAPU8.buffer.slice(raster, raster + width * height * 4);
        Tiff.Module.ccall('free', 'number', ['number'], [raster]);
        return data;
    };

    Tiff.prototype.toCanvas = function () {
        var width = this.width();
        var height = this.height();
        var raster = Tiff.Module.ccall('_TIFFmalloc', 'number', ['number'], [width * height * 4]);
        var result = Tiff.Module.ccall('TIFFReadRGBAImageOriented', 'number', ['number', 'number', 'number', 'number', 'number', 'number'], [
            this._tiffPtr, width, height, raster, 1, 0
        ]);

        if (result === 0) {
            throw new Tiff.Exception('The function TIFFReadRGBAImageOriented returns NULL');
        }
        var image = Tiff.Module.HEAPU8.subarray(raster, raster + width * height * 4);

        var canvas = document.createElement('canvas');
        var context = canvas.getContext('2d');
        canvas.width = width;
        canvas.height = height;
        var imageData = context.createImageData(width, height);
        imageData.data.set(image);
        context.putImageData(imageData, 0, 0);
        Tiff.Module.ccall('free', 'number', ['number'], [raster]);
        return canvas;
    };

    Tiff.prototype.toDataURL = function () {
        return this.toCanvas().toDataURL();
    };

    Tiff.prototype.close = function () {
        Tiff.Module.ccall('TIFFClose', 'number', ['number'], [this._tiffPtr]);
    };

    Tiff.createUniqueFileName = function () {
        Tiff.uniqueIdForFileName += 1;
        return String(Tiff.uniqueIdForFileName) + '.tiff';
    };

    Tiff.createFileSystemObjectFromBuffer = function (buffer) {
        var filename = Tiff.createUniqueFileName();
        Tiff.Module.FS.createDataFile('/', filename, new Uint8Array(buffer), true, false);
        return filename;
    };
    Tiff.uniqueIdForFileName = 0;
    Tiff.Module = null;
    return Tiff;
})();

var Tiff;
(function (Tiff) {
    var Exception = (function () {
        function Exception(message) {
            this.message = message;
            this.name = 'Tiff.Exception';
        }
        return Exception;
    })();
    Tiff.Exception = Exception;

    Tiff.Tag = TiffTag;
})(Tiff || (Tiff = {}));

// for closure compiler
Tiff.prototype['width'] = Tiff.prototype.width;
Tiff.prototype['height'] = Tiff.prototype.height;
Tiff.prototype['currentDirectory'] = Tiff.prototype.currentDirectory;
Tiff.prototype['countDirectory'] = Tiff.prototype.countDirectory;
Tiff.prototype['setDirectory'] = Tiff.prototype.setDirectory;
Tiff.prototype['getField'] = Tiff.prototype.getField;
Tiff.prototype['readRGBAImage'] = Tiff.prototype.readRGBAImage;
Tiff.prototype['close'] = Tiff.prototype.close;
Tiff['Exception'] = Tiff.Exception;
Tiff['initialize'] = Tiff.initialize;


if (typeof process === 'object' && typeof require === 'function') {
    module['exports'] = Tiff;
} else if (typeof define === "function" && define.amd) {
    define('tiff', [], function () {
        return Tiff;
    });
} else if (typeof window === 'object') {
    window['Tiff'] = Tiff;
} else if (typeof importScripts === 'function') {
    self['Tiff'] = Tiff;
}
//# sourceMappingURL=tiff_api.js.map
