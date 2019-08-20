pipeline {
    agent any
	
	parameters {
        string(defaultValue: "APIDemo.sln", description: 'Solution File', name: 'solution')
		string(defaultValue: "XUnitTestProjectAPI/XUnitTestProjectAPI.csproj", description: 'Test File', name: 'test')
		string(defaultValue: "testapi", description: 'Docker Image', name: 'image')
		string(defaultValue: "asmitasharma28/webapi", description: 'Repository Name', name: 'repository')
		string(defaultValue: "aswebapi", description: 'Tag', name: 'tag')
		string(defaultValue: "8089", description: 'Port No. to Bind to', name: 'toPort')
		string(defaultValue: "6001", description: 'Port No. to Bind from', name: 'fromPort')

    }
	
    stages { 
        stage('Build') {
        	
        	steps{
        		echo '==================================Building===================================='
        		bat 'dotnet build %solution% -p:Configuration=release -v:q'
        	}
        }
        stage('Test') {
        	
        	steps{
        		echo '================================Testing======================================='
        		bat 'dotnet test %test%'
        	}
        }
        stage('Publish') {
        	
        	steps{
        		echo '====================================Publishing==================================='
        		bat 'dotnet publish %solution% -c RELEASE -o Publish'
        	}
        }
		
		stage('Docker Image Build') {
        	
        	steps{
        		echo '=====================Building Docker Image============================================'
        		bat 'docker build -t %image% -f Dockerfile .'				
        	}
        }
		
		
		stage('Dockerhub Login') {
        	
        	steps{
				withCredentials([usernamePassword(credentialsId: 'webapi', passwordVariable: 'pass', usernameVariable: 'user')])  {

					echo '==============================Login to Dockerhub================================='
					bat 'docker login -p %pass% -u %user%'
	
				}	
        			
        	}
        }
		stage('Push Image') {
        	
        	steps{
        		echo '=============================Pushing Image to Dockerhub========================================='
				bat 'docker tag %image% %repository%:%tag%'
				bat 'docker push %repository%:%tag%' 
				bat 'docker rmi %image%:latest'
				bat 'docker rmi %repository%:%tag%'
        	}
        }
		
		stage('Pull Image') {
        	
        	steps{
        		echo '================================Pulling image from Dockerhub========================================'
				bat 'docker pull %repository%:%tag%'        		
        	}
        }
		
		stage('Run image') {
        	
        	steps{
        		echo '=====================================Run the image==============================================='
				bat 'docker run -p %toPort%:%fromPort% %repository%:%tag% '        		
        	}
        }
		stage('SonarQube stage') {
        	
        	steps{
        		echo '======================================Run the sonarqube template=========================================='
				  
				bat 'dotnet C:/Users/assharma/Downloads/sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0/SonarScanner.MSBuild.dll begin /k:"api" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="c743884dfc09f8eed0c24e8c32a1dcf0611eafd6"'
				bat 'dotnet build'
				bat 'dotnet C:/Users/assharma/Downloads/sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0/SonarScanner.MSBuild.dll end /d:sonar.login="c743884dfc09f8eed0c24e8c32a1dcf0611eafd6"'
        	}
        }
		
    }
}
