pipeline {

    agent 'master'

    stages {

        stage('Build') {
            steps {
                echo '=======================Build Process==========================='
				sh 'dotnet build APIDemo.sln -p:Configuration=release -v:q'
            }
        }

        stage('Test') {
            steps {
                echo '===========================Testing Process=============================='
				sh 'dotnet test XUnitTestProjectAPI/XUnitTestProjectAPI.csproj -p:Configuration=release -v:q'
            }
        }
    }	

	post  {
     	success{
     		archiveArtifacts artifacts: '**', fingerprint:true
			sh 'dotnet APIDemo/bin/Release/netcoreapp2.1/APIDemo.dll'
     		   }
		 }
	}
