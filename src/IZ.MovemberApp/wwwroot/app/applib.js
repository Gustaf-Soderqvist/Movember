(function(){"use strict";angular.module("movember",["ui.router","ngAnimate","ngCookies"])})();(function(){"use strict";angular.module("movember").directive("fileDropzone",fileDropzone);function fileDropzone(){var directive={link:link,restrict:"A",scope:{file:"=",fileName:"="}};return directive;function link(scope,element,attrs){var checkSize,isTypeValid,processDragOverOrEnter,validMimeTypes;processDragOverOrEnter=function(event){if(event!=null){event.preventDefault()}event.dataTransfer.effectAllowed="copy";return false};validMimeTypes=attrs.fileDropzone;checkSize=function(size){var _ref;if((_ref=attrs.maxFileSize)===void 0||_ref===""||size/1024/1024<attrs.maxFileSize){return true}else{alert("File must be smaller than "+attrs.maxFileSize+" MB");return false}};isTypeValid=function(type){if(validMimeTypes===void 0||validMimeTypes===""||validMimeTypes.indexOf(type)>-1){return true}else{alert("Invalid file type.  File must be one of following types "+validMimeTypes);return false}};element.bind("dragover",processDragOverOrEnter);element.bind("dragenter",processDragOverOrEnter);return element.bind("drop",function(event){var file,name,reader,size,type;if(event!=null){event.preventDefault()}reader=new FileReader;reader.onload=function(evt){if(checkSize(size)&&isTypeValid(type)){return scope.$apply(function(){scope.file=evt.target.result;if(angular.isString(scope.fileName)){return scope.fileName=name}})}};file=event.dataTransfer.files[0];name=file.name;type=file.type;size=file.size;reader.readAsDataURL(file);return false})}}})();(function(){"use strict";angular.module("movember").factory("posts",posts);posts.$inject=["$http","$log"];function posts($http,$log){$log.info("Post called");var service={save:save,load:get,list:list,remove:remove};function save(post){return $http.post("/api/post",post).then(function(res,status,headers,config){return res.data})}function remove(id){return $http.delete("/api/post/"+id).then(function(res,status,headers,config){return res.data})}function get(id){return $http.get("/api/post/"+id).then(function(res,status,headers,config){return res.data})}function list(){return $http.get("/api/post").then(function(res,status,headers,config){return res.data})}return service}})();"use strict";angular.module("movember").factory("AuthenticationService",["Base64","$http","$cookieStore","$rootScope","$timeout",function(Base64,$http,$cookieStore,$rootScope,$timeout){var service={};service.Login=function(username,callback,Email){$http.post("/api/UserData/"+Email,{username:username}).success(function(response){callback(response)})};service.SetCredentials=function(username){var authdata=Base64.encode(username);$rootScope.globals={currentUser:{username:username,authdata:authdata}};$http.defaults.headers.common["movember"]="Basic "+authdata;$cookieStore.put("globals",$rootScope.globals)};service.ClearCredentials=function(){$rootScope.globals={};$cookieStore.remove("globals");$http.defaults.headers.common.movember="Basic "};return service}]).factory("Base64",function(){var keyStr="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";return{encode:function(input){var output="";var chr1,chr2,chr3="";var enc1,enc2,enc3,enc4="";var i=0;do{chr1=input.charCodeAt(i++);chr2=input.charCodeAt(i++);chr3=input.charCodeAt(i++);enc1=chr1>>2;enc2=(chr1&3)<<4|chr2>>4;enc3=(chr2&15)<<2|chr3>>6;enc4=chr3&63;if(isNaN(chr2)){enc3=enc4=64}else if(isNaN(chr3)){enc4=64}output=output+keyStr.charAt(enc1)+keyStr.charAt(enc2)+keyStr.charAt(enc3)+keyStr.charAt(enc4);chr1=chr2=chr3="";enc1=enc2=enc3=enc4=""}while(i<input.length);return output},decode:function(input){var output="";var chr1,chr2,chr3="";var enc1,enc2,enc3,enc4="";var i=0;var base64test=/[^A-Za-z0-9\+\/\=]/g;if(base64test.exec(input)){window.alert("There were invalid base64 characters in the input text.\n"+"Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n"+"Expect errors in decoding.")}input=input.replace(/[^A-Za-z0-9\+\/\=]/g,"");do{enc1=keyStr.indexOf(input.charAt(i++));enc2=keyStr.indexOf(input.charAt(i++));enc3=keyStr.indexOf(input.charAt(i++));enc4=keyStr.indexOf(input.charAt(i++));chr1=enc1<<2|enc2>>4;chr2=(enc2&15)<<4|enc3>>2;chr3=(enc3&3)<<6|enc4;output=output+String.fromCharCode(chr1);if(enc3!=64){output=output+String.fromCharCode(chr2)}if(enc4!=64){output=output+String.fromCharCode(chr3)}chr1=chr2=chr3="";enc1=enc2=enc3=enc4=""}while(i<input.length);return output}}});(function(){"use strict";angular.module("movember").filter("dateFilter",function($filter){return function(input,format,timezone){return!!input?$filter("date")(Date.parse(input),format,timezone):""}})})();(function(){"use strict";angular.module("movember").run(run).config(function($stateProvider,$urlRouterProvider){$urlRouterProvider.otherwise("/");$stateProvider.state("list",{url:"/",views:{main:{templateUrl:"partials/list.html",controller:"ListPostController as vm",resolve:{postlist:function(posts){return posts.list()}}},title:{template:"Posts"}}}).state("login",{url:"/login",views:{main:{templateUrl:"partials/login.html",controller:"LoginController as vm"},title:{template:"Posts"}}}).state("new",{url:"/new",views:{main:{templateUrl:"partials/new.html",controller:"NewPostController as vm"},title:{template:"New post"}}}).state("edit",{url:"/edit/:id",views:{main:{templateUrl:"partials/edit.html",controller:"EditPostController as vm"},title:{template:"Edit post"}}})});run.$inject=["$rootScope","$location","$cookieStore","$http"];function run($rootScope,$location,$cookieStore,$http){$rootScope.globals=$cookieStore.get("globals")||{};if($rootScope.globals.currentUser){$http.defaults.headers.common["movember"]="Basic "+$rootScope.globals.currentUser.authdata}$rootScope.$on("$locationChangeStart",function(event,next,current){if($location.path()!=="/login"&&!$rootScope.globals.currentUser){$location.path("/login")}})}})();
//# sourceMappingURL=applib.js.map