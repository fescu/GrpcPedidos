pipeline {
    agent any

    stages {

        stage('Checkout') {
            steps {
                git url: 'https://github.com/fescu/GrpcPedidos.git'
            }
        }

        stage('Build Docker') {
            steps {
                sh 'docker compose build'
            }
        }

        stage('Run Containers') {
            steps {
                sh 'docker compose up -d'
            }
        }

        stage('Test Health Endpoint') {
            steps {
                sh 'curl -f http://localhost:5295/check-mongo'
            }
        }
    }

    post {
        always {
            sh 'docker compose down'
        }
    }
}
