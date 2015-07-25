angular.module('root', ['services'])
    .controller("products",
    [
        "$scope", '$http', 'appSettings', function($scope, $http, appSettings) {
            var getProductsUri = appSettings.apiServiceBaseUri + 'api/products/';
            var saveProductUri = appSettings.apiServiceBaseUri + 'api/products/AddProduct';
            $scope.showAddProductDiv = true;
            $scope.showProductsDiv = function() {
                return $scope.products != null && $scope.products.length > 0 ? true : false;
            }


            $scope.getNewProduct = function () {
                return {
                    Name: "",
                    Code: "",
                    Id: "",
                    Description: "",
                    UnitPrice: "",
                    BuyingPrice: "",
                    CurrentlyAvailable: ""
                };
            }

            $scope.showAddProduct = function() {
                $scope.showAddProductDiv = false;
                $scope.showProductsDiv = false;
            }

            $scope.cancelSaveProduct = function () {
                $scope.showAddProductDiv = true;
                $scope.showProductsDiv = true;
            }

            $scope.saveNewProduct = function () {
                $scope.showAddProductDiv = true;
                $scope.showProductsDiv = true;
                $scope.products[$scope.products.length] = $scope.newProduct;

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
            };

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