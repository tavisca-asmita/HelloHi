pipeline {

    agent any

    stages {

        stage('Build') {
            steps {
                echo '=======================Build Process==========================='
				bat 'dotnet build APIDemo.sln -p:Configuration=release -v:q'
            }
        }

        stage('Test') {
            steps {
                echo '===========================Testing Process=============================='
				bat 'dotnet test XUnitTestProjectAPI/XUnitTestProjectAPI.csproj -p:Configuration=release -v:q'
            }
        }

		stage('Publish') {
            steps {
                echo '===========================Publish=============================='
				bat 'dotnet publish'
            }
        }
    }	
}
