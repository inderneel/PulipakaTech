angular.module('root', ['services'])
    .controller("products",
    [
        "$scope", '$http', 'appSettings', function ($scope, $http, appSettings) {
            var getProductsUri = appSettings.apiServiceBaseUri + 'api/products/GetAllProducts';
            var uploadImageUri = appSettings.apiServiceBaseUri + 'api/products/SaveImage';
            var saveProductUri = appSettings.apiServiceBaseUri + 'api/products/SaveProduct';
            $scope.showAddProductDiv = false;
            $scope.showProductsDiv = true;
            $scope.showAddImageDiv = false;
            $scope.showAddImageButton = false;
            $scope.FileData = null;

            $scope.showProductsDiv = function() {
                return $scope.products != null && $scope.products.length > 0 ? true : false;
            }

            $scope.SaveProductText = "Add Product";
            $scope.getNewImage = function() {
                return {
                    Id: "",
                    Name: "",
                    Description: "",
                    ProductId: "",
                    PictureData: null
                };
            }
            $scope.getNewProduct = function () {
                return {
                    Name: "",
                    Code: "",
                    Id: "",
                    Description: "",
                    UnitPrice: "",
                    BuyingPrice: "",
                    CurrentlyAvailable: "",
                    Images: null
                };
            }
            
            $scope.setFile = function (file) {
                $scope.FileData = file;
            }
            $scope.uploadImage = function() {
                var fd = new FormData();
                fd.append("file", $scope.FileData);

                $http.post(uploadImageUri,fd, {
                        /*withCredentials: true,*/
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity,
                        data: fd,
                        /*contentType: false,*/
                        /*processData: false*/
                    }).success(function(data, status, headers, config) {
                        $scope.Message = 'Success';
                    //$scope.saveImageInfo(data);
                }).error(function(data, status, headers, config) {
                    $scope.Message = 'Error';
                });
/*
                var response = $('#frmSaveImage').submit(
                    /*function () {
                    $.post($(this).attr('action'), $(this).serialize(), function(json) {
                        alert(json);
                    }, 'json');
                    }#1#
                );

                alert(response);*/

            }
            $scope.cancelAddImages = function () {
                $scope.showAddProductDiv = true;
                $scope.showAddImageDiv = false;
                $scope.showAddImageButton = false;
            }
            $scope.addProductImages = function () {
                $scope.showAddProductDiv = false;
                $scope.showProductsDiv = false;
                $scope.showAddImageDiv = true;
                $scope.newImage = $scope.getNewImage();
                $scope.newImage.ProductId = $scope.newProduct.Id;
            }

            $scope.showAddProduct = function() {
                $scope.showAddProductDiv = true;
                $scope.showProductsDiv = false;
                $scope.SaveProductText = "Add Product";
                $scope.newProduct = $scope.getNewProduct();
            }

            $scope.showEditProduct = function (p) {
                $scope.newProduct = p;

                $scope.showAddProductDiv = true;
                $scope.showProductsDiv = false;
                $scope.showAddImageButton = true;
                $scope.SaveProductText = "Edit Product";
            }

            $scope.cancelSaveProduct = function () {
                $scope.showAddProductDiv = false;
                $scope.showProductsDiv = true;
            }

            $scope.saveProduct = function() {
                $scope.showAddProductDiv = false;
                $scope.showProductsDiv = true;

                $scope.SaveToServer();
            }

            $scope.saveNewProduct = function () {
                $scope.showAddProductDiv = false;
                $scope.showProductsDiv = true;
                $scope.products[$scope.products.length] = $scope.newProduct;

                $scope.SaveToServer();
            };

            $scope.SaveToServer = function ()
            {
                $http({
                    url: saveProductUri,
                    method: "POST",
                    data: $scope.newProduct,
                }).success(function (data, status, headers, config) {
                    $scope.Message = 'Success';
                    $scope.newProduct = $scope.getNewProduct();
                }).error(function (data, status, headers, config) {
                    $scope.Message = 'Error';
                });
            }

            $scope.newProduct = $scope.getNewProduct();
            
            $http.get(getProductsUri).success(
                function(result) {
                    $scope.products = result;
                }).error(
                function(err) {
                    alert(err);
                });
        }
    ]);