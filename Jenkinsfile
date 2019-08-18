pipeline {
    agent any
	
	parameters {
        string(defaultValue: "APIDemo.sln", description: 'Solution File', name: 'solution')
		string(defaultValue: "XUnitTestProjectAPI/XUnitTestProjectAPI.csproj", description: 'Test File', name: 'test')
		string(defaultValue: "testapi", description: 'Docker Image', name: 'image')
		string(defaultValue: "asmitasharma28/webapi", description: 'Repository Name', name: 'repository')

		string(defaultValue: "aswebapi", description: 'Tag', name: 'tag')
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
				withCredentials([string(credentialsId: 'password', variable: 'userCredentials')]) {

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
				bat 'docker run -p 8087:6001 %repository%:%tag% '        		
        	}
        }
		stage('SonarQube stage') {
        	
        	steps{
        		echo '======================================Run the image=========================================='
				bat 'docker run -p 8087:6001 %repository%:%tag% '        		
        	}
        }
		
    }
}
