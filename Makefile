.PHONY: deploy
deploy:
	docker build -t safonovva/safonovva-gitlab-webhook .
	docker push safonovva/safonovva-gitlab-webhook
	heroku container:push web --app safonovva-gitlab-webhook
	heroku container:release web --app safonovva-gitlab-webhook
